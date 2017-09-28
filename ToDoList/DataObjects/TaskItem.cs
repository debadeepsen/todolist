using System.Xml;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System;

namespace ToDoList.DataObjects
{

    public class TaskItem
    {
        public int ID { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public bool Active { get; set; }



        public override string ToString()
        {
            string val = "";

            val = "(" + Priority + " priority) "
                + Caption
                + Environment.NewLine
                + Environment.NewLine
                + Description;

            return val;
        }

        public static void Serialize(List<TaskItem> items, string path)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<TaskItem>));
            FileStream file = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
            xml.Serialize(file, items);
            file.Close();
        }

        public static List<TaskItem> Deserialize(string path)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<TaskItem>));
            StreamReader file = new StreamReader(path);
            List<TaskItem> items = xml.Deserialize(file) as List<TaskItem>;
            file.Close();

            return items;
        }
    }
}
