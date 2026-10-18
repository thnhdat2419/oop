using System;
using System.Text;

namespace HW2
{
    class Program
    {
        // Kiểm tra hợp lệ dữ liệu và tạo đối tượng Person
        public static Person InputPersonInfo(string name, string address, string sSalary)
        {
            if (string.IsNullOrWhiteSpace(sSalary))
            {
                throw new Exception("Bạn phải nhập tiền lương.");
            }

            double salary;
            if (!double.TryParse(sSalary.Trim(), out salary))
            {
                throw new Exception("Lương phải là số, vui lòng nhập lại.");
            }

            if (salary <= 0)
            {
                throw new Exception("Lương phải lớn hơn 0.");
            }

            return new Person(name, address, salary);
        }

        // Hiển thị thông tin của 1 người
        public static void DisplayPersonInfo(Person person)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Thông tin người vừa nhập:");
            Console.WriteLine("Họ và tên: " + person.GetName());
            Console.WriteLine("Địa chỉ  : " + person.GetAddress());
            Console.WriteLine("Lương    : " + person.GetSalary());
        }

        // Sắp xếp danh sách người theo lương tăng dần (Bubble Sort)
        public static Person[] SortBySalary(Person[] persons)
        {
            if (persons == null || persons.Length == 0)
            {
                throw new Exception("Không thể sắp xếp danh sách người.");
            }

            int n = persons.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (persons[j] != null && persons[j + 1] != null)
                    {
                        if (persons[j].GetSalary() > persons[j + 1].GetSalary())
                        {
                            Person temp = persons[j];
                            persons[j] = persons[j + 1];
                            persons[j + 1] = temp;
                        }
                    }
                }
            }
            return persons;
        }

        static void Main(string[] args)
        {
            // Thiết lập font hiển thị tiếng Việt có dấu trong Console
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            int totalPerson = 3;
            Person[] persons = new Person[totalPerson];

            Console.WriteLine("===== CHƯƠNG TRÌNH QUẢN LÝ THÔNG TIN PERSON =====");

            for (int i = 0; i < totalPerson; i++)
            {
                Console.WriteLine($"\n--- Nhập thông tin người thứ {i + 1} ---");
                Console.Write("Vui lòng nhập họ tên: ");
                string name = Console.ReadLine()?.Trim();

                Console.Write("Vui lòng nhập địa chỉ: ");
                string address = Console.ReadLine()?.Trim();

                Person person = null;
                while (person == null)
                {
                    Console.Write("Vui lòng nhập lương: ");
                    string sSalary = Console.ReadLine();
                    try
                    {
                        person = InputPersonInfo(name, address, sSalary);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi: " + ex.Message);
                    }
                }
                persons[i] = person;
            }

            Console.WriteLine("\n===== DANH SÁCH SAU KHI SẮP XẾP LƯƠNG TĂNG DẦN =====");
            try
            {
                persons = SortBySalary(persons);
                foreach (Person p in persons)
                {
                    DisplayPersonInfo(p);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }

            Console.WriteLine("\nNhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}
