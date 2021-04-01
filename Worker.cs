/****************************** Module Header ******************************\
Module Name: Worker.cs
Project: LAB06
Author: Travis Thaxter
Date: 13/12/2019
Copyright (c) Microsoft Corporation.

Adapted from PieceworkWorker by Kyle Chapman, September 2019

This is a class representing individual worker objects. Each stores
their own name and number of messages and the class methods allow for
calculation of the worker's pay and for updating of shared summary
values. Name and messages are received as strings.
This is being used as part of a piecework payroll application.

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
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;
using System.Data;

namespace LAB06___Travis_Thaxter
{
    public abstract class Worker
    {

        #region "Variable declarations"

        // Instance variables
        protected int employeeID;
        protected string employeeFirstName;
        protected string employeeLastName;
        protected int employeeMessages;
        protected decimal employeePay;
        protected DateTime entryDate;
        protected string employeeType;


        #endregion

        #region "Constructors"

        /// <summary>
        /// Worker constructor: empty constructor used strictly for inheritance and instantiation
        /// </summary>
        public Worker()
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
        protected abstract void FindPay();
        #endregion

        #region "Property Procedures"
        /// <summary>
        /// Gets a worker's full name
        /// </summary>
        /// <returns>an employee's name</returns>
        public string Name
        {
            get
            {
                return employeeFirstName + " " + employeeLastName;
            }
        }

        /// <summary>
        /// Gets and sets a worker's first name
        /// </summary>
        /// <returns>an employee's first name</returns>
        public string FirstName
        {
            get
            {
                return employeeFirstName;
            }
            set
            {
                employeeFirstName = ValidateName(value, "FirstNameError");
            }
        }

        /// <summary>
        /// Gets and sets a worker's last name
        /// </summary>
        /// <returns>an employee's last name</returns>
        public string LastName
        {
            get
            {
                return employeeLastName;
            }
            set
            {
                employeeLastName = ValidateName(value, "LastNameError");
            }
        }

        protected string ValidateName(string name, string errorCode)
        {
            const int minLetter = 2;
            if (name == "") // true if the input was blank.
            {
                throw new ArgumentNullException(errorCode, "The worker's name cannot be blank."); // null exception.
            }
            else if (Regex.Matches(name, @"[a-zA-Z]").Count < minLetter) // true if the input has at least 2 letters in it.
            {
                throw new ArgumentException("The worker's name must be at least " + minLetter + " letters long.", errorCode); // argument doesn't meet criteria exception.
            }
            else // input is valid
            {
                return name;
            }
        }
        /// <summary>
        /// Gets and sets the number of messages sent by a worker
        /// </summary>
        /// <returns>an employee's number of messages</returns>
        public string Messages
        {
            get
            {
                return employeeMessages.ToString();
            }
            set
            {
                const int lowerBound = 1;
                const int upperBound = 20000;
                if (int.TryParse(value, out int input) && input >= lowerBound && input <= upperBound) // true if value is an int above 0, also declares input as an int variable
                {
                    employeeMessages = input;
                }
                else if (value == "") // true if the input is a blank string, throws appropriate exception.
                {
                    throw new ArgumentNullException("MessagesBlank", "The messages sent cannot be blank."); // null exception.
                }
                else // must be false, throw the all-requirements descriptive exception.
                {
                    throw new ArgumentOutOfRangeException("OutOfRange", "The messages sent must be a whole number and must be \nbetween " + lowerBound + " and " + upperBound + "."); // input is not numeric or is out of acceptable range.
                }
            }
        }

        /// <summary>
        /// Gets and sets the worker's pay
        /// </summary>
        /// <returns>a worker's pay</returns>
        public decimal Pay
        {
            get
            {
                return employeePay;
            }
            set
            {
                employeePay = value;
            }
        }

        /// <summary>
        /// Gets the worker's messages
        /// </summary>
        /// <returns>a worker's messages sent</returns>
        public static int TotalMessages
        {
            get
            {
                return Convert.ToInt32(DBL.GetTotal(DBL.Totals.Messages));
            }
        }

        /// <summary>
        /// Gets the overall total pay among all workers
        /// </summary>
        /// <returns>the overall total pay among all workers</returns>
        public static decimal TotalPay
        {
            get
            {
                return Convert.ToDecimal(DBL.GetTotal(DBL.Totals.Pay));
            }
        }

        /// <summary>
        /// Gets the overall number of workers
        /// </summary>
        /// <returns>the overall number of workers</returns>
        public static int TotalWorkers
        {
            get
            {
                return Convert.ToInt32(DBL.GetTotal(DBL.Totals.Employees));
            }
        }

        /// <summary>
        /// Calculates and returns an average pay among all workers
        /// </summary>
        /// <returns>the average pay among all workers</returns>
        public static decimal AveragePay
        {
            get
            {
                return (TotalWorkers > 0 ? TotalPay / TotalWorkers : 0); // formula for average is total of values added divided by the population of the values.
            }
        }

        /// <summary>
        /// gets and sets employees id
        /// </summary>
        /// <returns>the employee's id</returns>
        public int Id
        {
            get
            {
                return employeeID;
            }
            set
            {
                employeeID = value;
            }
        }

        /// <summary>
        /// gets and sets worker's type
        /// </summary>
        internal string Type
        {
            get
            {
                return employeeType;
            }
            set
            {
                employeeType = value;
            }
        }

        /// <summary>
        /// gets and sets the date the data was input.
        /// </summary>
        public DateTime EntryDate
        {
            get
            {
                return entryDate;
            }
            set
            {
                entryDate = value;
            }
        }
        /// <summary>
        /// returns the list of employees
        /// </summary>
        public static DataTable AllWorkers
        {
            get
            {
                return DBL.GetEmployeeList();
            }
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

