namespace DatabaseTests
{
    using System;
    using Database;
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private const int DatabaseCapacity = 16;
        private Database database;

        [SetUp]
        public void SetUp()
        {
            this.database = new Database();
        }

        [Test]
        public void ThrowsExeptionIfUsingAddOperationWhenDatabaseIsFull()
        {
            // Act

            this.AddElements(DatabaseCapacity);

            // Assert

            Assert.Throws<InvalidOperationException>(() => this.database.Add(7));
        }
        [Test]
        public void CanNotUseRemoveOperationWhenDatabaseIsEmpty()
        {
            // Assert
            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        [TestCase(3)]
        [TestCase(8)]
        [TestCase(16)]
        public void AddNumbersInDtabasseIncreasesCount(int numberOfAdditions)
        {
            // Act
            this.AddElements(numberOfAdditions);

            // Assert
            Assert.AreEqual(numberOfAdditions, this.database.Count, "Adding numbers doesn't update the count correctly");
        }

        [Test]
        [TestCase(3, 1)]
        [TestCase(8, 4)]
        [TestCase(16, 10)]
        public void RemoveNumbersFromDtabasseDecreasessCount(int numberOfAdditions, int numberOfRemovals)
        {
            // Act
            this.AddElements(numberOfAdditions);
            this.RemoveElements(numberOfRemovals);

            // Assert
            var expectedCount = numberOfAdditions - numberOfRemovals;
            Assert.AreEqual(expectedCount, this.database.Count, "Removing numbers doesn't update the count correctly");
        }

        [Test]
        [TestCase(3)]
        [TestCase(8)]
        [TestCase(16)]
        public void FetchReturnsCorrectNumberOfElementsFromDatabaseAfterAddition(int numberOfAdditions)
        {
            // Act
            this.AddElements(numberOfAdditions);
            var databaseContent = this.database.Fetch();

            // Assert
            Assert.AreEqual(numberOfAdditions, databaseContent.Length);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(8)]
        [TestCase(16)]
        public void FetchReturnsCorrectElementsFromDatabaseAfterAddition(int numberOfAdditions)
        {
            // Act
            this.AddElements(numberOfAdditions);
            var databaseContent = this.database.Fetch();

            // Assert
            for (int i = 0; i < numberOfAdditions; i++)
            {
                Assert.AreEqual(i, databaseContent[i]);
            }
        }

        [Test]
        [TestCase(3, 1)]
        [TestCase(8, 4)]
        [TestCase(16, 10)]
        public void FetchReturnsCorrectLengthOfElementsFromDatabaseAfterRemoval(int numberOfAdditions, int numberOfRemovals)
        {
            // Act
            this.AddElements(numberOfAdditions);
            this.RemoveElements(numberOfRemovals);
            var databaseContent = this.database.Fetch();

            // Assert
            var expectedNumberOfElements = numberOfAdditions - numberOfRemovals;
            Assert.AreEqual(expectedNumberOfElements, databaseContent.Length);
        }

        [Test]
        [TestCase(3, 1)]
        [TestCase(8, 4)]
        [TestCase(16, 10)]
        public void FetchReturnsCorrectElementsFromDatabaseAfterRemoval(int numberOfAdditions, int numberOfRemovals)
        {
            // Act
            this.AddElements(numberOfAdditions);
            this.RemoveElements(numberOfRemovals);
            var databaseContent = this.database.Fetch();

            // Assert
            for (int i = 0; i < numberOfAdditions - numberOfRemovals; i++)
            {
                Assert.AreEqual(i, databaseContent[i]);
            }
        }

        [Test]
        [TestCase(2)]
        [TestCase(2, 3)]
        [TestCase(2, 3, 4, 5)]
        [TestCase(2, 3, 4, 5, 6, 7)]
        [TestCase(2, 3, 4, 5, 6, 7, 8, 9)]
        public void DirectDatabaseInitializationConstructorWithCollectionOfNumbersWorksCorrectly(params int[] numbers)
        {
            // Arrange
            this.database = new Database(numbers);

            // Act
            this.database.Add(int.MaxValue);
            this.database.Remove();
            var databaseContent = this.database.Fetch();

            // Assert
            for (int i = 0; i < numbers.Length; i++)
            {
                Assert.AreEqual(databaseContent[i], numbers[i]);
            }
        }

        [Test]
        [TestCase(1, 2)]
        [TestCase(int.MinValue, int.MaxValue)]
        public void DirectDatabaseInitializationConstructorWithVariousNumberOfNumbersWorksCorrectly(int firstNumber, int secondNumber)
        {
            // Arrange
            this.database = new Database(firstNumber, secondNumber);

            // Act
            var databaseContent = this.database.Fetch();

            // Assert
            Assert.AreEqual(firstNumber, databaseContent[0]);
            Assert.AreEqual(secondNumber, databaseContent[1]);
        }

        [Test]
        public void CanNotInitializeDatabaseWithCollectionContainingMoreThanItsCapacity()
        {
            // Arrange
            var testCollection = new int[DatabaseCapacity + 1];

            // Assert
            Assert.Throws<InvalidOperationException>(() => this.database = new Database(testCollection));
        }

        [Test]
        public void DatabaseInitializationWithNullResultsInEmptyDataBase()
        {
            // Assert
            Assert.DoesNotThrow(() => this.database = new Database(null));
        }

        private void RemoveElements(int numberOfRemovals)
        {
            for (int i = 0; i < numberOfRemovals; i++)
            {
                this.database.Remove();
            }
        }

        public void AddElements(int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.database.Add(i);
            }
        }
    }
}
