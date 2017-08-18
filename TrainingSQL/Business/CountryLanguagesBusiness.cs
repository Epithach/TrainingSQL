using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingSQL.Datasource;
using System.Threading.Tasks;

namespace TrainingSQL.Business
{
    public class CountryLanguagesBusiness
    {
        public List<string> CheckOfficialLanguage(string language, bool isOfficial)
        {
            var datasource = CountryLanguagesDatasource.GetInstance();


            List<string> list = new List<string>();

            var taskList = new List<Task>();


            /*for (int i = 0; i < 2; i++)
            {
                var currentTask = new Task(() => datasource.CheckOfficialLanguage(language, isOfficial));
                currentTask.Start();
                taskList.Add(currentTask);
            }

            Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
            dictionary.Add("English", true);
            dictionary.Add("French", true);
            dictionary.Add("Dari", false);
            dictionary.Add("Uzbek", true);
            dictionary.Add("Ambo", false);

            Parallel.ForEach(dictionary, element =>
            {
                list.AddRange(datasource.CheckOfficialLanguage(element.Key, element.Value));
            });

    
//            Task<List<string>> task1 = Task<List<string>>.Factory.StartNew(() => datasource.CheckOfficialLanguage(language, isOfficial));
      //      return list;

    */
            return datasource.CheckOfficialLanguage(language, isOfficial);
        }

        
    }
}