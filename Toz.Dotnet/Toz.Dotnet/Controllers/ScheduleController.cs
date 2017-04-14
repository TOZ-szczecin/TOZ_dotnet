﻿using Microsoft.AspNetCore.Mvc;
using Toz.Dotnet.Core.Interfaces;
using Toz.Dotnet.Models;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Toz.Dotnet.Resources.Configuration;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Globalization;

namespace Toz.Dotnet.Controllers
{
    public class ScheduleController : Controller
    {
        private const int DaysCount = 14;
        
        private IScheduleManagementService _scheduleManagementService;
        private IUsersManagementService _usersManagementService;
        private readonly IStringLocalizer<ScheduleController> _localizer;
        private readonly AppSettings _appSettings;
        private DateTime _startDate;
                
        public ScheduleController(IScheduleManagementService scheduleManagementService, IUsersManagementService usersManagementService,
                                  IStringLocalizer<ScheduleController> localizer, IOptions<AppSettings> appSettings)
        {
            _scheduleManagementService = scheduleManagementService;
            _usersManagementService = usersManagementService;
            _localizer = localizer;
            _appSettings = appSettings.Value;
            _startDate = _scheduleManagementService.GetFirstDayOfWeek(DateTime.Now);
        }

        public async Task<IActionResult> Index(DateTime startDate, CancellationToken cancellationToken)
        {
            if (startDate != DateTime.MinValue)
            {
                _startDate = startDate;
            }
                        
            Schedule schedule = await _scheduleManagementService.GetSchedule(_startDate, _startDate.AddDays(DaysCount - 1));
            return View(schedule);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReservation(
            [Bind("FirstName, LastName")]
            UserBase userData, CancellationToken cancellationToken)
        {
            User user = null;

            if (userData != null && ModelState.IsValid)
            {
                user = await _usersManagementService.FindUser(userData.FirstName, userData.LastName);
                
                if (user == null)
                {
                    user.FirstName = userData.FirstName;
                    user.LastName = userData.LastName;

                    await _usersManagementService.CreateUser(user);
                    user = await _usersManagementService.FindUser(userData.FirstName, userData.LastName);

                    if (user == null)
                    {
                        return BadRequest();
                    }
                }
            }
            else
            {
                return View(userData);
            }

            Reservation reservation = new Reservation();
            reservation.OwnerId = user.Id;
            //Get number of slot
            //Based on a chosen Period assign Date, EndTime, StartTime to reservation object
            
            if (await _scheduleManagementService.MakeReservation(reservation))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest();
            }
            
        }

        public IActionResult AddReservation()
        {
            //Store information about slot number  
            return View(new UserBase());
        }
        
        public async Task<ActionResult> DeleteReservation(string id, CancellationToken cancellationToken)
        {
            var reservation = await _scheduleManagementService.GetReservation(id);
            var user = await _usersManagementService.GetUser(reservation.OwnerId);

            if (reservation != null)
            {
                await _scheduleManagementService.DeleteReservation(reservation);
            }

            return RedirectToAction("Index");
        }
    }
}
