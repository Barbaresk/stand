using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;

namespace VirtualStand
{
    /// <summary>
    /// Терм условия появления слоя изображения на элементе.
    /// </summary>
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

        public static string ToStr(Actions action)
        {
            switch(action)
            {
                case Actions.Equal: return "=";
                case Actions.Less: return "<";
                case Actions.More: return ">";
                default: return "";
            }
        }

        public static bool Check(string name)
        {
            Regex con16 = new Regex("^0[xX][0-9a-fA-F]+$");
            Regex con10 = new Regex("^[0-9]+$");
            Regex con2 = new Regex("^[01]+b$");
            if (con16.IsMatch(name))
                return true;
            if (con10.IsMatch(name))
                return true;
            if (con2.IsMatch(name))
                return true;
            return false;
        }

        public bool Correct(List<bool> list)
        {
            int v = 0;
            foreach (bool b in list)
                v = v * 2 + (b ? 1 : 0);

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

        public void Write(XmlTextWriter writer)
        {
            writer.WriteStartElement("condition");
            writer.WriteAttributeString("name", pin.Name);
            writer.WriteAttributeString("value", value);
            writer.WriteAttributeString("action", ToStr(action));
            writer.WriteEndElement();
        }
    }
}