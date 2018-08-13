using HackerNewsWebScraper.Interfaces;
using NUnit.Framework;

namespace HackerNewsWebScraper.Tests
{
    [TestFixture]
    public class HackerNewsStoryValidatorTests
    {
        private IHackerNewsStoryItemValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new HackerNewsStoryItemValidator();
        }

        [Test]
        public void HackerNewsStoryItemValidator_ValidateTitle_EmptyString_ReturnsFalse()
        {
            //Arrange    
            var title = string.Empty;

            //Act
            var result = _validator.IsTitleValid(title);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void HackerNewsStoryItemValidator_ValidateTitle_StringOver256Chars_ReturnsFalse()
        {
            //Arrange
            var title = new string('a', 257);

            //Act
            var result = _validator.IsTitleValid(title);

            //Assert
            Assert.IsFalse(result);

        }

        [Test]
        public void HackerNewsStoryItemValidator_ValidateTitle_ValidTitle_ReturnsTrue()
        {
            //Arrange
            const string title = "mytitle";

            //Act
            var result = _validator.IsTitleValid(title);

            //Assert
            Assert.IsTrue(result);

        }


        [Test]
        public void HackerNewsStoryItemValidator_ValidateUri_InvalidUri_ReturnsFalse()
        {
            //Arrange
            const string uri = "abs";

            //Act
            var result = _validator.IsUriValid(uri);

            //Assert
            Assert.IsFalse(result);

        }

        [Test]
        public void HackerNewsStoryItemValidator_ValidateUri_SettingsUri_ReturnsTrue()
        {
            //Arrange
            const string uri = HackerNewsConstants.HackerNewsUri;

            //Act
            var result = _validator.IsUriValid(uri);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void HackerNewsStoryItemValidator_ValidateAuthor_EmptyString_ReturnsFalse()
        {
            //Arrange
            var author = string.Empty;

            //Act
            var result = _validator.IsAuthorValid(author);

            //Assert
            Assert.IsFalse(result);

        }

        [Test]
        public void HackerNewsStoryItemValidator_ValidateAuthor_StringOver256Chars_ReturnsFalse()
        {
            //Arrange
            var author = new string('b', 257);

            //Act
            var result = _validator.IsAuthorValid(author);

            //Assert
            Assert.IsFalse(result);

        }

        [Test]
        public void HackerNewsStoryItemValidator_ValidateAuthor_ValidAuthor_ReturnsTrue()
        {
            //Arrange
            const string author = "author 1";

            //Act
            var result = _validator.IsAuthorValid(author);

            //Assert
            Assert.IsTrue(result);

        }

        [Test]
        public void HackerNewsStoryItemValidator_ValidateRank_NegativeNumber_ReturnsFalse()
        {
            //Arrange
            const int rank = -300;

            //Act
            var result = _validator.IsRankValid(rank);

            //Assert
            Assert.IsFalse(result);

        }

        [Test]
        public void HackerNewsStoryItemValidator_ValidateRank_PositiveInteger_ReturnsTrue()
        {
            //Arrange
            const int rank = 24;

            //Act
            var result = _validator.IsRankValid(rank);

            //Assert
            Assert.IsTrue(result);

        }

        [Test]
        public void HackerNewsStoryItemValidator_ValidateComments_NegativeInteger_ReturnsFalse()
        {
            //Arrange
            const int rank = -34;

            //Act
            var result = _validator.IsCommentsValid(rank);

            //Assert
            Assert.IsFalse(result);

        }

        [Test]
        public void HackerNewsStoryItemValidator_ValidateComments_PositiveInteger_ReturnsTrue()
        {
            //Arrange
            const int comment = 245;

            //Act
            var result = _validator.IsCommentsValid(comment);

            //Assert
            Assert.IsTrue(result);

        }

        [Test]
        public void HackerNewsStoryItemValidator_ValidatePoints_NegativeNumber_ReturnsFalse()
        {
            //Arrange
            const int points = -345;

            //Act
            var result = _validator.IsPointsValid(points);

            //Assert
            Assert.IsFalse(result);

        }

        [Test]
        public void HackerNewsStoryItemValidator_ValidatePoints_PositiveInteger_ReturnsTrue()
        {
            //Arrange
            const int points = 24;

            //Act
            var result = _validator.IsPointsValid(points);

            //Assert
            Assert.IsTrue(result);

        }

    }
}
