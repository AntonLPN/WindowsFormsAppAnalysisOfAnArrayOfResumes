using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
//Задание №1
//С использованием PLINQ cоздайте приложение для анализа массива резюме.
//Каждое резюме находится в файле. Формат файла фиксированный.
//Пользователь может загрузить одно резюме, несколько резюме или все резюме в
//папке. Загрузка резюме выполняется с помощью механизмов параллельного
//программирования. Приложение должно поддерживать следующие отчёты:
//• самый опытный кандидат (по количеству лет опыта);
//• самый неопытный кандидат (по количеству лет опыта);
//• кандидат с самыми низкими зарплатными требованиями;
//• кандидат с самыми высокими зарплатными требованиями.
//Используйте механизмы параллельного программирования для
//формирования отчётов.
//Отчёты отображаются в окне приложения.
//Задание №2
//Добавьте в первое задание возможность сгенерировать отчет по кандидатам
//из одного города.


namespace WindowsFormsAppAnalysisOfAnArrayOfResumes
{
    public partial class Form1 : Form
    {
        List<Person> list;
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод для сериализации обьектов в формате xml
        /// </summary>
        public void MethodSerialization()
        {
            Person person1 = new Person { FirstName = "Ivan", LastName = "Petrov", Age = 25, Experience = 5, City = "Kyiv", Salary = 3999 };
            Person person2 = new Person { FirstName = "Jhon", LastName = "Doe", Age = 30, Experience = 6, City = "Kyiv", Salary = 4000 };
            Person person3 = new Person { FirstName = "Tom", LastName = "Hanks", Age = 50, Experience = 20, City = "USA", Salary = 150000 };
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            List<Person> ListPeaople = new List<Person>();

            ListPeaople.Add(person1);
            ListPeaople.Add(person2);
            ListPeaople.Add(person3);

            foreach (var item in ListPeaople)
            {
                string nameFile = item.LastName + ".xml";
                using (FileStream fs = new FileStream(nameFile, FileMode.Create, FileAccess.Write, FileShare.Write))
                {
                  
                    serializer.Serialize(fs, item);
                    MessageBox.Show("File was saved successfully!");
                }
            }

              
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            //произвел сериализацию обьектов для использования
           // MethodSerialization();
        }

        /// <summary>
        /// Метод десиарилизации 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private Person GetPersonFromFile(string filename)
        {
            Person person = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                person = serializer.Deserialize(fs) as Person;
            }
            return person;
        }



        /// <summary>
        /// Событие загрузки только одного файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoadOnlyOneSummary_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            Parallel.Invoke(() =>{
                try
                {
                    if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;
                    // получаем выбранный файл
                    string filename = openFileDialog1.FileName;
                    Person person = GetPersonFromFile(filename);
                    textBox1.Text += "Last name :" + person.LastName + Environment.NewLine;
                    textBox1.Text += "First name :" + person.FirstName + Environment.NewLine;
                    textBox1.Text += "Age :" + person.Age.ToString() + Environment.NewLine;
                    textBox1.Text += "City :" + person.City + Environment.NewLine;
                    textBox1.Text += "Salary :" + person.Salary + Environment.NewLine;
                    textBox1.Text += "Expirience :" + person.Experience.ToString() + Environment.NewLine;

                    MessageBox.Show("Файл открыт");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

            });

          
        }
        /// <summary>
        /// Событие загрузки нескольких файлов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoadSomeSummary_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
             list = new List<Person>();

            Parallel.Invoke(()=> {

                try
                {
                    OpenFileDialog dlg = new OpenFileDialog
                    {
                        Multiselect = true,
                    };

                    if (dlg.ShowDialog() == DialogResult.Cancel)
                        return;
                    // пользователь вышел из диалога ничего не выбрав
                    if (dlg.FileName == String.Empty)
                        return;
                    foreach (string file in dlg.FileNames)
                    {
                        list.Add(GetPersonFromFile(file));
                    }

                    foreach (var person in list)
                    {
                        textBox1.Text += "Last name :" + person.LastName + Environment.NewLine;
                        textBox1.Text += "First name :" + person.FirstName + Environment.NewLine;
                        textBox1.Text += "Age :" + person.Age.ToString() + Environment.NewLine;
                        textBox1.Text += "City :" + person.City + Environment.NewLine;
                        textBox1.Text += "Salary :" + person.Salary + Environment.NewLine;
                        textBox1.Text += "Expirience :" + person.Experience.ToString() + Environment.NewLine;
                        textBox1.Text += "----------------------------------------------" + Environment.NewLine;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            });

           

        }
        /// <summary>
        /// Событие загрузки отчета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReport_Click(object sender, EventArgs e)
        {

            if (list.Count>1)
            {
              //наибольший опыт работы
               var exp = list.AsParallel<Person>().Select((n, i) => (n.Experience, Index: i)).Max();
                //наименьший опыт работы
               var expMin= list.AsParallel<Person>().Select((n, i) => (n.Experience, Index: i)).Min();
                //• кандидат с самыми низкими зарплатными требованиями;
                var minSalary= list.AsParallel<Person>().Select((n, i) => (n.Salary, Index: i)).Min();
                //• кандидат с самыми высокими зарплатными требованиями.
                var maxSalary = list.AsParallel<Person>().Select((n, i) => (n.Salary, Index: i)).Max();


                Person person =list.ElementAt(exp.Index);
                textBox1.Text += "**********************************************" + Environment.NewLine;
                textBox1.Text+= "Employee with long work experience" + Environment.NewLine;
                textBox1.Text += "Last name :" + person.LastName + Environment.NewLine;
                textBox1.Text += "First name :" + person.FirstName + Environment.NewLine;
                textBox1.Text += "Age :" + person.Age.ToString() + Environment.NewLine;
                textBox1.Text += "City :" + person.City + Environment.NewLine;
                textBox1.Text += "Salary :" + person.Salary + Environment.NewLine;
                textBox1.Text += "Expirience :" + person.Experience.ToString() + Environment.NewLine;
                textBox1.Text += "----------------------------------------------" + Environment.NewLine;

                Person personMin = list.ElementAt(expMin.Index);
                textBox1.Text += "**********************************************" + Environment.NewLine;
                textBox1.Text += "Employee with the least work experience" + Environment.NewLine;
                textBox1.Text += "Last name :" + personMin.LastName + Environment.NewLine;
                textBox1.Text += "First name :" + personMin.FirstName + Environment.NewLine;
                textBox1.Text += "Age :" + personMin.Age.ToString() + Environment.NewLine;
                textBox1.Text += "City :" + personMin.City + Environment.NewLine;
                textBox1.Text += "Salary :" + personMin.Salary + Environment.NewLine;
                textBox1.Text += "Expirience :" + personMin.Experience.ToString() + Environment.NewLine;
                textBox1.Text += "----------------------------------------------" + Environment.NewLine;

                Person personMinSalary = list.ElementAt(minSalary.Index);
                textBox1.Text += "**********************************************" + Environment.NewLine;
                textBox1.Text += "The candidate with the lowest salary requirements" + Environment.NewLine;
                textBox1.Text += "Last name :" + personMinSalary.LastName + Environment.NewLine;
                textBox1.Text += "First name :" + personMinSalary.FirstName + Environment.NewLine;
                textBox1.Text += "Age :" + personMinSalary.Age.ToString() + Environment.NewLine;
                textBox1.Text += "City :" + personMinSalary.City + Environment.NewLine;
                textBox1.Text += "Salary :" + personMinSalary.Salary + Environment.NewLine;
                textBox1.Text += "Expirience :" + personMinSalary.Experience.ToString() + Environment.NewLine;
                textBox1.Text += "----------------------------------------------" + Environment.NewLine;


                Person personMaxSalary = list.ElementAt(maxSalary.Index);
                textBox1.Text += "**********************************************" + Environment.NewLine;
                textBox1.Text += "The candidate with the highest salary requirements" + Environment.NewLine;
                textBox1.Text += "Last name :" + personMaxSalary.LastName + Environment.NewLine;
                textBox1.Text += "First name :" + personMaxSalary.FirstName + Environment.NewLine;
                textBox1.Text += "Age :" + personMaxSalary.Age.ToString() + Environment.NewLine;
                textBox1.Text += "City :" + personMaxSalary.City + Environment.NewLine;
                textBox1.Text += "Salary :" + personMaxSalary.Salary + Environment.NewLine;
                textBox1.Text += "Expirience :" + personMaxSalary.Experience.ToString() + Environment.NewLine;
                textBox1.Text += "----------------------------------------------" + Environment.NewLine;



            }
            else
            {
                MessageBox.Show("Choose more than one employee","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void buttonCandidatsFromOneCity_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            var queryLondonCustomers = from cust in list.AsParallel()
                                       where cust.City == "Kyiv"
                                       select cust;

            foreach (var item in queryLondonCustomers)
            {
                textBox1.Text += "**********************************************" + Environment.NewLine;
                textBox1.Text += "The candidate with the highest salary requirements" + Environment.NewLine;
                textBox1.Text += "Last name :" + item.LastName + Environment.NewLine;
                textBox1.Text += "First name :" + item.FirstName + Environment.NewLine;
                textBox1.Text += "Age :" + item.Age.ToString() + Environment.NewLine;
                textBox1.Text += "City :" + item.City + Environment.NewLine;
                textBox1.Text += "Salary :" + item.Salary + Environment.NewLine;
                textBox1.Text += "Expirience :" + item.Experience.ToString() + Environment.NewLine;
                textBox1.Text += "----------------------------------------------" + Environment.NewLine;
            }



        }

      

    }
}
