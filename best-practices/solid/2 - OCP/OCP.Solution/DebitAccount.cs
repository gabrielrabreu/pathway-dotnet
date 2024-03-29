﻿using System;
using System.Linq;

namespace OCP.Solution
{
    public abstract class DebitAccount
    {
        public string TransactionNumber { get; set; }
        public abstract string Debit(decimal amount, string account);

        public string FormatTransaction()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            TransactionNumber = new string(Enumerable.Repeat(chars, 15)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            return TransactionNumber;
        }
    }
}
