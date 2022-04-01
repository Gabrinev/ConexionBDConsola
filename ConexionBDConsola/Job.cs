using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBDConsola
{
    class Job
    {
        int _id;
        String _workstation;
        decimal _minSalary;
        decimal _maxSalary;

        public Job(int id, String ws, decimal min, decimal max)
        {
            _id = id;
            _workstation = ws;
            _minSalary = min;
            _maxSalary = max;
        }
        public Job(String ws, decimal min, decimal max)
        {

            _workstation = ws;
            _minSalary = min;
            _maxSalary = max;
        }

        public int id
        {
            get
            {
                return _id;
            }
        }
        public String workstation
        {
            get
            {
                return _workstation;
            }
        }

        public decimal minSalary
        {
            get
            {
                return _minSalary;
            }
        }

        public decimal maxSalary
        {
            get
            {
                return _maxSalary;
            }
        }

        public override string ToString()
        {
            return "ID: " + this.id + " PUESTO: " + this.workstation + " SALARIO MINIMO " + minSalary + " SALARIO MAXIMO " + maxSalary;
        }

    }
}
