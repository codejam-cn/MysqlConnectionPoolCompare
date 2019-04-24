using System;

namespace MysqlConnectionPoolCompare.Model
{
    public class q_4_1_single_table
    {
        public int id { get; set; }
        public int exam_rep_no { get; set; }
        public string question_description { get; set; }
        public string option_a { get; set; }
        public string option_b { get; set; }
        public string option_c { get; set; }
        public string option_d { get; set; }
        public string option_e { get; set; }
        public int right_answer { get; set; }
        public string analysis { get; set; }
        public int status { get; set; }
        public DateTime input_time { get; set; }
    }
}
