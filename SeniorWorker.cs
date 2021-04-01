/****************************** Module Header ******************************\
Module Name: SeniorWorker.cs
Project: LAB06
Author: Travis Thaxter
Date: 13/12/2019
Copyright (c) Microsoft Corporation.

Class definition of behaviors and attributes for senior workers.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.
THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAB06___Travis_Thaxter
{
    public class SeniorWorker : PieceworkWorker
    {
        #region "Constructors"
        /// <summary>
        /// SeniorWorker constructor: accepts a worker's name and number of
        /// messages, sets and calculates values as appropriate, id is optional.
        /// </summary>
        /// <param name="firstNameValue"></param>
        /// <param name="lastNameValue"></param>
        /// <param name="messagesValue"></param>
        /// <param name="id"></param>
        public SeniorWorker(string firstNameValue, string lastNameValue, string messagesValue, int id = -1)
        {
            // Validate and set the worker's first name
            this.FirstName = firstNameValue;
            // Validate and set the worker's last name
            this.LastName = lastNameValue;
            // Validate Validate and set the worker's number of messages
            this.Messages = messagesValue;
            // Validate and set the worker's id
            this.Id = (id >= 0 ? id : -1);
            // Calculcate the worker's pay and update all summary values
            FindPay();
            // Set time created to now
            this.EntryDate = DateTime.Now;
            // Type for this class is always Piecework
            this.Type = "Senior";
            // Updates row if it exists, inserts new record if not.
            DBL.UpdateExistingRow(this);
        }

        /// <summary>
        /// SeniorWorker constructor: empty constructor used strictly for inheritance and instantiation
        /// </summary>
        public SeniorWorker()
        {

        }

        #endregion

        #region "Class methods"

        /// <summary>
        /// Currently called in the constructor, the findPay() method is
        /// used to calculate a worker's pay using threshold values to
        /// change how much a worker is paid per message. This also updates
        /// all summary values.
        /// </summary>
        protected override void FindPay()
        {
            const decimal basePay = 150.0M; // base pay for seniors
            decimal[] payRate = new[] { 0.0325m, 0.027m, 0.022m, 0.017m, 0.011m }; // array containing payment per bracket
            int[] messageBracket = new[] { 10000, 7500, 5000, 2500, 0 }; // array containing bounds of each bracket
            for (int i = 0; i <= messageBracket.Length; i++) // for each bracket
            {
                if (employeeMessages >= messageBracket[i]) // true if messages is equal to or greater than the start for that bracket.
                {
                    employeePay = employeeMessages * payRate[i];
                    i = messageBracket.Length + 1; // "break" once it reaches a true statement because all following statements will be true.
                }
            }
            employeePay += basePay; // adds senior workers base pay to total.
        }
        /// <summary>
        /// Concatenates senior worker to the string conversion.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + " - Senior Worker";
        }
        #endregion
    }
}