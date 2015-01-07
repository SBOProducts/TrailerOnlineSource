using DealerBLL.Themes;
using Moq;
using Ninject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealer.UnitTests.ThemeTests
{
    [TestFixture]
    public class When_using_theme_manager
    {

        IThemeManager manager;
        
        
        List<ThemeMetadata> _themes = new List<ThemeMetadata>(){
            new ThemeMetadata() { Name = "First", FolderPath = @"C:\First\" },
            new ThemeMetadata() { Name = "Second", FolderPath = @"C:\Second\" },
            new ThemeMetadata() { Name = "Third",  FolderPath = @"C:\Third\" }
        };


        [SetUp]
        public void Setup()
        {
            var _mockThemeRepository = new Mock<IThemeRepository>();
            
            // setup the list
            _mockThemeRepository.Setup(m => m.InstalledThemes).Returns(_themes);
            
            // when GetByName is called then return the item from the _themes list with the same name
            //_mockThemeRepository.Setup(m => m.GetByName(It.IsAny<string>())).Returns((string s) => _themes.Find(t => t.Name == s));
            
            manager = new ThemeManager(_mockThemeRepository.Object);
        }


        [Test]
        public void I_can_get_a_list_of_all_installed_themes()
        {
            IEnumerable<ThemeMetadata> expected = _themes;
            
            IEnumerable<ThemeMetadata> actual = manager.GetAllInstalledThemes();

            Assert.AreEqual(expected.Count(), actual.Count());
        }





        [Test]
        public void I_can_get_count_the_installed_themes()
        {
            int expected = 3;
            int actual = manager.InstalledThemeCount();
            
            Assert.AreEqual(expected, actual);
        }



        



    }
}
