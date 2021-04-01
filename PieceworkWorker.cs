/****************************** Module Header ******************************\
Module Name: PieceworkWorker.cs
Project: LAB06
Author: Travis Thaxter
Date: 13/12/2019
Copyright (c) Microsoft Corporation.

Class definition of behaviors and attributes for Piecework workers.

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
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;

namespace LAB06___Travis_Thaxter
{
    public class PieceworkWorker : Worker
    {
        #region "Constructors"

        /// <summary>
        /// PieceworkWorker constructor: accepts a worker's name and number of
        /// messages, sets and calculates values as appropriate, id is optional.
        /// </summary>
        /// <param name="firstNameValue"></param>
        /// <param name="lastNameValue"></param>
        /// <param name="messagesValue"></param>
        /// <param name="id"></param>
        public PieceworkWorker(string firstNameValue, string lastNameValue, string messagesValue, int id = -1)
        {
            // Validate and set the worker's first name
            this.FirstName = firstNameValue;
            // Validate and set the worker's last name
            this.LastName = lastNameValue;
            // Validate and set the worker's number of messages
            this.Messages = messagesValue;
            // Validate and set the worker's id
            this.Id = (id >= 0 ? id : -1);
            // Calculcate the worker's pay and update all summary values
            FindPay();
            // Set time created to now
            this.EntryDate = DateTime.Now;
            // Type for this class is always Piecework
            this.Type = "Piecework";
            // Updates row if it exists, inserts new record if not.
            DBL.UpdateExistingRow(this);
        }


        /// <summary>
        /// PieceworkWorker constructor: empty constructor used strictly for inheritance and instantiation
        /// </summary>
        public PieceworkWorker()
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
            decimal[] payRate = new[] { 0.040m, 0.035m, 0.030m, 0.024m, 0.018m }; // array containing payment per bracket
            int[] messageBracket = new[] { 10000, 7500, 5000, 2500, 0 }; // array containing bounds of each bracket
            for (int i = 0; i <= messageBracket.Length; i++) // for each bracket
            {
                if (employeeMessages >= messageBracket[i]) // true if messages is equal to or greater than the start for that bracket.
                {
                    employeePay = employeeMessages * payRate[i];
                    i = messageBracket.Length + 1; // "break" once it reaches a true statement because all following statements will be true.
                }
            }
        }
        /// <summary>
        /// Overrides the to string operator, allowing the object to be displayed in a chosen format.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return FirstName + " " + LastName + " - " + Messages + " - " + String.Format("{0:c}", Pay);
        }
        #endregion
    }
}

/* “Why are some property procedures in this class read/write while others are read-only?”
 * They vary because some of the procedures are intended to edit the values they are returning, and some are simply meant to return the value.
 * "Pay" simply returns a value.
 * Whereas "Name" & "Messages" both validate and set values.
 * +1 more bonus stock: "AveragePay" does a calculation, but only to return it, not store it in any variable.
 */

/* “Why are exceptions thrown in order from most specific to least specific?”
 * Exceptions are thrown in this order because you can't see the top of a pyramid from under it.
 */

