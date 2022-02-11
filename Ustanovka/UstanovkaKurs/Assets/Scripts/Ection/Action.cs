using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Ection
{
    public class Action
    {
        public bool Status { get; set; }
        public string Message { get; set; }

        public Action(bool status, string message)
        {
            Status = status;
            Message = message;
        }
    }
}
