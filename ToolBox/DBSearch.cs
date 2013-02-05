using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolBox
{
    public class DBSearch
    {
        public enum status
        {
            both = 0,
            single = 1,
            married = 2
        }

        public enum gender
        {
            both = 0,
            male = 1,
            female = 2
        }

        public string queryField;
        public string queryTerm;
        public status queryStatus;
        public gender queryGender;

        public DBSearch(string qField, string qTerm, status qStatus, gender qGender)
        {
            this.queryField = qField;
            this.queryTerm = qTerm;
            this.queryGender = qGender;
            this.queryStatus = qStatus;
        }
    }
}
