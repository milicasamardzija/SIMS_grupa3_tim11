using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class Feedback : Entity
    {
        public FeedbackType type { get; set; }
        public int grade { get; set; }
        public String comment { get; set; }
        public String problem { get; set; }
        public String email { get; set; }

        public Feedback() { }

        public Feedback(int id, FeedbackType type, int grade, String comment, String problem, String email) : base(id){
            this.type = type;
            this.grade = grade;
            this.comment = comment;
            this.problem = problem;
            this.email = email;
        }
        public Feedback(int id, FeedbackType type, int grade, String comment) : base(id)
        {
            this.type = type;
            this.grade = grade;
            this.comment = comment;
          
        }
    }
}
