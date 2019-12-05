using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

namespace listApp
{
    public partial class MainWindow
    {
        private const string xmlFilenameRUsers = "data/rUsers.xml";
        private const string xmlFilenameManagers = "data/managers.xml";
        private const string xmlFilenameAdministrators = "data/administrators.xml";

        private bool XMLSave()
        {
            XmlSerializer xsRUsers = new XmlSerializer(typeof(ObservableCollection<Regular>));
            XmlSerializer xsManagers = new XmlSerializer(typeof(ObservableCollection<Manager>));
            XmlSerializer xsAdministrators = new XmlSerializer(typeof(ObservableCollection<Administrator>));

            try
            {
                using (Stream writer = File.Create(xmlFilenameRUsers))
                {
                    xsRUsers.Serialize(writer, users);
                }

                using (Stream writer = File.Create(xmlFilenameManagers))
                {
                    xsManagers.Serialize(writer, managers);
                }

                using (Stream writer = File.Create(xmlFilenameAdministrators))
                {
                    xsAdministrators.Serialize(writer, administrators);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }


        private bool XMLLoad()
        {
            XmlSerializer xsRUsers = new XmlSerializer(typeof(ObservableCollection<Regular>));
            XmlSerializer xsManagers = new XmlSerializer(typeof(ObservableCollection<Manager>));
            XmlSerializer xsAdministrators = new XmlSerializer(typeof(ObservableCollection<Administrator>));

            try
            {
                if (File.Exists(xmlFilenameRUsers))
                {
                    using (Stream reader = File.OpenRead(xmlFilenameRUsers))
                    {
                        users = (ObservableCollection<Regular>)xsRUsers.Deserialize(reader);
                    }
                }

                if (File.Exists(xmlFilenameManagers))
                {
                    using (Stream reader = File.OpenRead(xmlFilenameManagers))
                    {
                        managers = (ObservableCollection<Manager>)xsManagers.Deserialize(reader);
                    }
                }

                if (File.Exists(xmlFilenameAdministrators))
                {
                    using (Stream reader = File.OpenRead(xmlFilenameAdministrators))
                    {
                        administrators = (ObservableCollection<Administrator>)xsAdministrators.Deserialize(reader);
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

    }
}
