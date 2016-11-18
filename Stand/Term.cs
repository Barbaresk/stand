using System;
using System.Text.RegularExpressions;

namespace VirtualStand
{
    class Term
    {
        public enum Actions { Equal, More, Less, Undefined }

        private Actions action;
        private string value;
        private InPin pin;

        public string Name
        {
            get
            {
                return pin.Name;
            }
        }

        public Term(InPin pin, string value, Actions action)
        {
            this.action = action;
            this.value = value;
            this.pin = pin;
        }

        public static Actions ToAction(string action)
        {
            switch(action)
            {
                case "=": return Actions.Equal;
                case ">": return Actions.More;
                case "<": return Actions.Less;
                default : return Actions.Undefined;
            }
        }

        public bool Correct(string value)
        {
            int v = 0;

            Regex reg16 = new Regex("^0[xX]([0-9a-fA-F]+)$");
            Regex reg10 = new Regex("^([0-9]+)$");
            Regex reg2 = new Regex("^([01]+)b$");
            if (reg16.IsMatch(value))
                v = Convert.ToInt32(reg16.Match(value).Groups[1].Value, 16);
            else if (reg10.IsMatch(value))
                v = Convert.ToInt32(reg10.Match(value).Groups[1].Value, 10);
            else if (reg2.IsMatch(value))
                v = Convert.ToInt32(reg2.Match(value).Groups[1].Value, 2);
            else
                return false;

            string con = new string(this.value.ToLower().ToCharArray());
            Regex con16 = new Regex("^0[xX][0-9a-fA-FuU]+$");
            Regex con10 = new Regex("^[0-9uU]+$");
            Regex con2 = new Regex("^[01uU]+b$");
            int r = 0;
            if (con16.IsMatch(con))
                r = 16;
            else if (con10.IsMatch(con))
                r = 10;
            else if (con2.IsMatch(con))
                r = 2;
            else
                return false;

            if (action == Actions.Equal)
            {
                if (r == 16)
                {
                    string condValue = con.Remove(0, 2);
                    string numValue = Convert.ToString(v, 16).ToLower();
                    if (numValue.Length < condValue.Length)
                        numValue = new string('0', condValue.Length - numValue.Length) + numValue;
                    else
                        condValue = new string('u', numValue.Length - numValue.Length) + condValue;
                    for (int i = 0; i < condValue.Length; ++i)
                        if (condValue[i] != 'u' && numValue[i] != 'u' && numValue[i] != condValue[i])
                            return false;
                }
                else if (r == 10)
                {
                    string condValue = con;
                    string numValue = Convert.ToString(v, 10);
                    if (numValue.Length < condValue.Length)
                        numValue = new string('0', condValue.Length - numValue.Length) + numValue;
                    else
                        condValue = new string('u', numValue.Length - numValue.Length) + condValue;
                    for (int i = 0; i < condValue.Length; ++i)
                        if (condValue[i] != 'u' && numValue[i] != 'u' && numValue[i] != condValue[i])
                            return false;
                }
                else if (r == 2)
                {
                    string condValue = con.Remove(con.Length - 1, 1);
                    string numValue = Convert.ToString(v, 2);
                    if (numValue.Length < condValue.Length)
                        numValue = new string('0', condValue.Length - numValue.Length) + numValue;
                    else
                        condValue = new string('u', numValue.Length - numValue.Length) + condValue;
                    for (int i = 0; i < condValue.Length; ++i)
                        if (condValue[i] != 'u' && numValue[i] != 'u' && numValue[i] != condValue[i])
                            return false;
                }
                else
                    return false;
            }
            else 
            {
                Regex regNEq = new Regex("(^[0-9]+$)|(^0[xX][0-9a-fA-F]+$)|(^[01]+b$)");
                if (!regNEq.IsMatch(value))
                    return false;
                int condValue = Convert.ToInt32(con, r);
                if (action == Actions.Less && v >= condValue ||
                    action == Actions.More && v <= condValue)
                    return false;
            }
            return true;
        }
    }
}