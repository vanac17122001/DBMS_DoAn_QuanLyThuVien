using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class user
    {
        private string _name;
        private string _pass;
        private string _quyen;

        public user()
        { }
        public user(string name, string pass)
        {
            this._name = name;
            this._pass = pass;
        }

        public string Name { get => _name; set => _name = value; }
        public string Pass { get => _pass; set => _pass = value; }
        public string Quyen { get => _quyen; set => _quyen = value; }
    }
}
