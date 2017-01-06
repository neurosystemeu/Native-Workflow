using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ExpressionEvaluator;

namespace NeuroSystem.Workflow.Core.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Pobiera wartosc obiektu dla scieżki propercji path
        /// np. obiekt= Pracownik, path=Kontrahent.Nazwa -> zwraca nazwe kontrahenta danego pracownika
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Object GetPropValue(this Object obj, String path)
        {
            var registry = new TypeRegistry();
            registry.RegisterSymbol("obiekt", obj);  // registers the symbol 'm' with instance myClass

            string sciezka = "";
            if (path.StartsWith("["))
            {
                sciezka = "obiekt" + path;
            }
            else
            {
                sciezka = "obiekt." + path;
            }

            var expression = new CompiledExpression(sciezka) { TypeRegistry = registry };
            var result = expression.Eval();
            return result;

        }

        public static T GetPropValue<T>(this Object obj, String path)
        {
            Object retval = GetPropValue(obj, path);
            if (retval == null) { return default(T); }

            // throws InvalidCastException if types are incompatible
            return (T)retval;
        }

        public static void SetPropValue(this Object obiekt, String path, object wartosc)
        {
            var elementySciezki = path.Split('.');

            if (elementySciezki.Count() == 1)
            {
                //mamy samą nazwę, więc ustawiamy wartosc dla obiektu o nazwie path
                ustawWartosc(obiekt, path, wartosc);
            }
            else
            {
                //mamy więcej elementow sciezki
                var elementyBezOstatniego = elementySciezki.Take(elementySciezki.Count() - 1);
                var sciezkaDoObiektuPrzedostatniego = string.Join(".", elementyBezOstatniego);

                obiekt = GetPropValue(obiekt, sciezkaDoObiektuPrzedostatniego);
                //foreach (String part in elementyBezOstatniego)
                //{
                //    if (obiekt == null) { return; } //obiekt jest null

                //    Type type = obiekt.GetType();
                //    PropertyInfo info = type.GetProperty(part);
                //    if (info == null) { return; } //niema takiej propercji

                //    obiekt = info.GetValue(obiekt, null);
                //}

                ustawWartosc(obiekt, elementySciezki.Last(), wartosc);
            }
        }

        private static void ustawWartosc(object obiekt, string nazwaPropercji, object wartosc)
        {
            if (nazwaPropercji.Contains("["))
            {
                //mamy tablice
                var t = nazwaPropercji.Split('[');
                if (string.IsNullOrEmpty(t[0]))
                {
                    var tt = t[1].Split(']');
                    //mamy samą tablice bez propercji
                    dynamic d = obiekt;
                    var key = tt[0].Replace("\"", "");
                    d[key] = (string)wartosc;
                }
                else
                {
                    var tt = t[1].Split(']');
                    var key = tt[0].Replace("\"", "");

                    var typ = obiekt.GetType();
                    var propercja = typ.GetProperty(t[0]);
                    var o = propercja.GetValue(obiekt);
                    dynamic d = o;
                    d[key] = wartosc;
                }

            }
            else
            {
                var typ = obiekt.GetType();
                var propercja = typ.GetProperty(nazwaPropercji);

                if (propercja.PropertyType != typeof(string) && wartosc is string)
                {
                    //mamy przepisanie z stringa do jakiegoś obiektu
                    //czyli bindowaliśmy z jakiejś kontrolki z tekstem lub serializowaliśmy i musimy to parsować na dany obiekt
                    var wartoscStringowa = (string)wartosc;
                    ustawWartoscPropercji(obiekt, propercja, wartoscStringowa);
                }
                else
                {
                    // ustawiamy wartosc
                    propercja.SetValue(obiekt, wartosc);
                }
            }
        }


        /// <summary>
        /// Metoda ustawia wartosc propercji dla obiektu 'obiekt' podaną w stringu.
        /// Jeśli propercja jest np int to automatycznie parsuje stringa na int, jeśli jest datą parsuje na date itd.        /// 
        /// </summary>
        /// <param name="obiekt"></param>
        /// <param name="propercja"></param>
        /// <param name="wartoscStringowa"></param>
        private static void ustawWartoscPropercji(object obiekt, PropertyInfo propercja, string wartoscStringowa)
        {
            if (propercja.PropertyType.FullName.Contains("Nullable") && string.IsNullOrEmpty(wartoscStringowa))
            {
                propercja.SetValue(obiekt, null, null);
            }
            else
                            if (propercja.PropertyType == typeof(System.Int32) || propercja.PropertyType == typeof(System.Int32?))
            {
                propercja.SetValue(obiekt, int.Parse(wartoscStringowa), null);
            }
            else if (propercja.PropertyType == typeof(System.Boolean) || propercja.PropertyType == typeof(System.Boolean?))
            {
                propercja.SetValue(obiekt, bool.Parse(wartoscStringowa), null);
            }
            else if (propercja.PropertyType == typeof(System.Guid) || propercja.PropertyType == typeof(System.Guid?))
            {
                propercja.SetValue(obiekt, Guid.Parse(wartoscStringowa), null);
            }
            else if (propercja.PropertyType == typeof(System.Double) || propercja.PropertyType == typeof(System.Double?))
            {
                propercja.SetValue(obiekt, Double.Parse(wartoscStringowa), null);
            }
            else if (propercja.PropertyType == typeof(System.Decimal) || propercja.PropertyType == typeof(System.Decimal?))
            {
                propercja.SetValue(obiekt, Decimal.Parse(wartoscStringowa), null);
            }
            else if (propercja.PropertyType == typeof(System.DateTime) || propercja.PropertyType == typeof(System.DateTime?))
            {
                propercja.SetValue(obiekt, DateTime.Parse(wartoscStringowa), null);
            }
            else if (propercja.PropertyType == typeof(System.String))
            {
                propercja.SetValue(obiekt, wartoscStringowa, null);
            }
        }


        /// <summary>
        /// Przepisuje wartosc z słownika do obiektu
        /// Wartość przepisywana jest do propercji o nazwie klucza słownika, 
        /// jeśli wartość jest stringiem to jest parsowana na odpowiedni typ
        /// </summary>
        /// <param name="obiekt"></param>
        /// <param name="values"></param>
        public static void UpdateValuesFromHashtable(this Object obiekt, IDictionary values)
        {
            Type MyType = obiekt.GetType();
            PropertyInfo[] a_Properties = MyType.GetProperties();

            foreach (string s_Key in values.Keys)
            {
                PropertyInfo propercja = a_Properties.FirstOrDefault(item => item.Name == s_Key);

                if (propercja == null || propercja.CanWrite == false)
                {
                    continue;
                }

                // jeśli jest nul to ustawiamy go a nie ignorujemy

                //if (values[s_Key] == null)
                //{
                //    continue;
                //}
                var wartosc = values[s_Key];

                if (propercja.PropertyType != typeof(string) && wartosc is string)
                {
                    //mamy przepisanie z stringa do jakiegoś obiektu
                    ustawWartoscPropercji(obiekt, propercja, values[s_Key].ToString());
                }
                else
                {
                    // ustawiamy wartosc
                    propercja.SetValue(obiekt, wartosc);
                }
            }
        }



        /// <summary>
        /// Przepisuje wartosci z obiektu do słownika.
        /// </summary>
        /// <param name="obiekt"></param>
        /// <param name="czyWszystkiePropercie">Jeśli tak to nulowe propercje też są przepisywane</param>
        /// <param name="values"></param>
        public static void UpdateValuesFromObject(this Object obiekt, IDictionary values,
            bool czyWszystkiePropercie = false,
            bool czyKolekcje = false)
        {
            Type MyType = obiekt.GetType();
            PropertyInfo[] a_Properties = MyType.GetProperties();

            foreach (var pi in a_Properties)
            {
                if (pi.PropertyType == typeof(System.Int32) || pi.PropertyType == typeof(System.Int32?))
                {
                    var wartosc = pi.GetValue(obiekt);
                    //if (wartosc != null)
                    {
                        values[pi.Name] = wartosc;
                    }
                }

                else if (pi.PropertyType == typeof(System.Boolean) || pi.PropertyType == typeof(System.Boolean?))
                {
                    var wartosc = pi.GetValue(obiekt);
                    //if (wartosc != null)
                    {
                        values[pi.Name] = wartosc;
                    }
                }
                else if (pi.PropertyType == typeof(System.Int64) || pi.PropertyType == typeof(System.Int64?))
                {
                    var wartosc = pi.GetValue(obiekt);
                    //if (wartosc != null)
                    {
                        values[pi.Name] = wartosc;
                    }
                }
                else if (pi.PropertyType == typeof(System.Double) || pi.PropertyType == typeof(System.Double?))
                {
                    var wartosc = pi.GetValue(obiekt);
                    //if (wartosc != null)
                    {
                        values[pi.Name] = wartosc;
                    }
                }
                else if (pi.PropertyType == typeof(System.Decimal) || pi.PropertyType == typeof(System.Decimal?))
                {
                    var wartosc = pi.GetValue(obiekt);
                    //if (wartosc != null)
                    {
                        values[pi.Name] = wartosc;
                    }
                }
                else if (pi.PropertyType == typeof(System.DateTime) || pi.PropertyType == typeof(System.DateTime?))
                {
                    var wartosc = pi.GetValue(obiekt);
                    //if (wartosc != null)
                    {
                        values[pi.Name] = wartosc;
                    }
                }
                else if (pi.PropertyType == typeof(System.Guid) || pi.PropertyType == typeof(System.Guid?))
                {
                    var wartosc = pi.GetValue(obiekt);
                    //if (wartosc != null)
                    {
                        values[pi.Name] = wartosc;
                    }
                }
                else if (pi.PropertyType.IsEnum)
                {
                    var wartosc = (int)pi.GetValue(obiekt);
                    //if (wartosc != null)
                    {
                        values[pi.Name] = wartosc;
                    }
                }
                else if (pi.PropertyType == typeof(System.String))
                {
                    var wartosc = pi.GetValue(obiekt);
                    //if (wartosc != null)
                    {
                        values[pi.Name] = wartosc;
                    }
                }
                else if (czyWszystkiePropercie)
                {
                    var wartosc = pi.GetValue(obiekt);

                    if (wartosc == null)
                    {
                        values[pi.Name] = null;
                    }
                    else
                    {
                        if (wartosc is IEnumerable)
                        {
                            //propercja jest kolekcja
                            if (czyKolekcje)
                            {
                                values[pi.Name] = wartosc;
                            }
                        }
                        else
                        {
                            values[pi.Name] = wartosc;
                        }
                    }
                }
            }

            foreach (string s_Key in values.Keys)
            {
                PropertyInfo pi = a_Properties.Single(item => item.Name == s_Key);

                Type t = pi.PropertyType;

                if (values[s_Key] == null)
                {
                    continue;
                }


            }
        }

        public static string GetPropertyDescription(this PropertyInfo pi)
        {
            var str = new StringBuilder();

            var description = pi.GetCustomAttributes(typeof(DescriptionAttribute));
            if (description != null)
            {
                foreach (DescriptionAttribute a in description)
                {
                    str.Append(a.Description);
                }
            }

            var display = pi.GetCustomAttributes(typeof(DisplayAttribute));
            if (display != null)
            {
                foreach (DisplayAttribute a in display)
                {
                    str.Append(a.Description);
                }
            }

            str.Append(" | ");
            str.Append(pi.Name);

            if (pi.PropertyType.IsEnum)
            {
                //pobieram opis enuma
                str.AppendLine();
                str.Append(GetClassDescription(pi.PropertyType));
            }

            return str.ToString();
        }

        public static string GetEnumDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static string GetMethodDescription(this MethodInfo pi)
        {
            var art = pi.GetCustomAttributes(typeof(DescriptionAttribute));
            var str = new StringBuilder();
            foreach (DescriptionAttribute a in art)
            {
                str.Append(a.Description);
            }

            str.Append(" - ");
            str.Append(pi.Name);
            str.AppendLine();

            foreach (var item in pi.GetParameters())
            {
                str.Append("'");
                str.Append(item.Name);
                str.Append("-");
                str.Append(item.ParameterType.GetClassDescription());
                str.Append("',");
            }

            return str.ToString();
        }

        public static string GetPropertyDescription(this object obiekt, string nazwaPropercji)
        {
            var typ = obiekt.GetType();
            var art = typ.GetProperty(nazwaPropercji).GetCustomAttributes(typeof(DescriptionAttribute));
            var str = new StringBuilder();
            foreach (DescriptionAttribute a in art)
            {
                str.Append(a.Description);
            }

            return str.ToString();
        }

        public static string GetClassDescription(this Type typ)
        {
            var art = typ.GetCustomAttributes(typeof(DescriptionAttribute));
            var str = new StringBuilder();
            foreach (DescriptionAttribute a in art)
            {
                str.Append(a.Description);
            }

            if (typ.IsEnum)
            {
                var wartosci = Enum.GetValues(typ);
                foreach (var enumVal in wartosci)
                {
                    str.AppendLine();
                    str.Append(enumVal.ToString());
                    str.Append(" - ");

                    var memInfo = typ.GetMember(enumVal.ToString());
                    var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                    foreach (DescriptionAttribute a in attributes)
                    {
                        str.Append(a.Description);
                    }
                }
            }

            return str.ToString();
        }

        public static string GetClassDescription(this object obiekt)
        {
            var typ = obiekt.GetType();
            var art = typ.GetCustomAttributes(typeof(DescriptionAttribute));
            var str = new StringBuilder();
            foreach (DescriptionAttribute a in art)
            {
                str.Append(a.Description);
            }

            return str.ToString();
        }

        /// <summary>
        /// Przepisuje dane z obiektu inny obiekt do obiektu this
        /// </summary>
        /// <param name="obiekt"></param>
        /// <param name="innyObiekt"></param>      
        /// <param name="czyWszystkiePropercie">Jeśli tak to nulowe propercje też są przepisywane</param>       
        public static void Mapuj(this object obiekt, object innyObiekt, bool czyWszystkiePropercje = false, bool czyKolekcje = false)
        {
            var hash = new Hashtable();
            innyObiekt.UpdateValuesFromObject(hash, czyWszystkiePropercje, czyKolekcje);
            obiekt.UpdateValuesFromHashtable(hash);
        }
    }

}
