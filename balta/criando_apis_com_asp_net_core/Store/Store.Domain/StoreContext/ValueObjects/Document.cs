using Flunt.Notifications;
using Flunt.Validations;

namespace Store.Domain.StoreContext.ValueObjects
{
    public class Document : Notifiable
    {
        public Document(string number)
        {
            Number = number;

            AddNotifications(new Contract().Requires()
                .IsCpf(number, nameof(Number), "Invalid document"));
        }

        public string Number { get; private set; }
    }

    static class ContractExtensions
    {
        public static Contract IsCpf(this Contract obj, string value, string property, string message)
        {
            bool Valid()
            {
                int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                string tempCpf;
                string digito;
                int soma;
                int resto;
                value = value.Trim();
                value = value.Replace(".", "").Replace("-", "");
                if (value.Length != 11)
                    return false;
                tempCpf = value.Substring(0, 9);
                soma = 0;

                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = resto.ToString();
                tempCpf = tempCpf + digito;
                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = digito + resto.ToString();
                return value.EndsWith(digito);
            }

            if (!Valid())
            {
                obj.AddNotification(property, message);
            }

            return obj;
        }
    }
}