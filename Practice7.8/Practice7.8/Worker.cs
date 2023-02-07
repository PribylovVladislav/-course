using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice7._8
{
    struct Worker
    {
        public int id { get; set; }
        public DateTime writeTime { get; set; }
        public string initials { get; set; }
        public byte age { get; set; }
        public byte height { get; set; }
        public DateTime birthday { get; set; }
        public string birthPlace { get; set; }

        public Worker(int id, DateTime writeTime, string initials, byte age,
            byte height, DateTime birthday, string birthPlace)
        {
            this.id = id;
            this.writeTime = writeTime;
            this.initials = initials;
            this.age = age;
            this.height = height;
            this.birthday = birthday;
            this.birthPlace = birthPlace;
        }

        public string ConvertWorkerToString(Worker worker)
        {

            return Convert.ToString(worker.id) + " " + Convert.ToString(worker.writeTime) + " " +
                worker.initials + " " + Convert.ToString(worker.age) + " " +
                Convert.ToString(worker.height) + " " + Convert.ToString(worker.birthday) + " " +
                worker.birthPlace;
        }
    }
}
