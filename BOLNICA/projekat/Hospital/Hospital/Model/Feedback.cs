using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class Feedback
    {
        private FeedbackType type;
        private int grade;
        private String comment;
        private String problem;
        private String email;

        public Feedback() { }

        public Feedback(FeedbackType type, int grade, String comment, String problem, String email) {
            this.type = type;
            this.grade = grade;
            this.comment = comment;
            this.problem = problem;
            this.email = email;
        }
        public Feedback(FeedbackType type, int grade, String comment, String problem)
        {
            this.type = type;
            this.grade = grade;
            this.comment = comment;
            this.problem = problem;
            
        }

    }
}
