﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class UserModel
    {
        public string Url { get; set; }
        public string DisplayName { get; set; }
        public DateTime CreateDate { get; set; }
        public string Location { get; set; }
        public int? Age { get; set; }

        public string QuestionsUrl { get; set; }
        public string AnswersUrl { get; set; }
        public string CommentsUrl { get; set; }
    }
}