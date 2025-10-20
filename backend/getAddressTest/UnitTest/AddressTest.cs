using api.Models;

namespace getAddressTest.UnitTest
{
    [TestFixture]
    [Category("UnitTest")]
    public class AddressTest
    {
        private Address _address;

        [SetUp]
        public void Setup()
        {
            _address = new Address();
        }

        #region Street validation
        [TestCase("Vesterbrogade")]
        [TestCase("Nørregade")]
        [TestCase("Åboulevard")]
        public void ValidateStreet_ValidStreet_DoesNotThrow(string street)
        {
            //arrange
            _address.Street = street;
            //act & assert
            Assert.DoesNotThrow(() => _address.ValidateStreet());
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("123Main")]
        [TestCase("Main st.")]
        //[TestCase("ThisStreetNameIsWayTooLongToBeValid")]
        public void ValidateStreet_InvalidStreet_ThrowsException(string? street)
        {
            //arrange
            _address.Street = street;
            //act & assert
            var ex = Assert.Catch(() => _address.ValidateStreet());
            //Contains
            Assert.That(
                ex.Message,
                Does.Contain($"Street {street} must be provided")
                    .Or.Contain($"Street {street} must only contain letters")
            );
        }
        #endregion

        #region Number validation
        [TestCase("1")] //lower boundary
        [TestCase("2")]
        [TestCase("500")] // middle value
        [TestCase("998")]
        [TestCase("999")] // upper boundary
        [TestCase("1B")] // lower boundary with letter
        [TestCase("500B")] // middle value with letter
        [TestCase("998A")]
        [TestCase("999A")] // upper boundary with letter
        public void ValidateNumber_ValidNumber_DoesNotThrow(string number)
        {
            //arrange
            _address.Number = number;
            //act & assert
            Assert.DoesNotThrow(() => _address.ValidateNumber());
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("0")] // lower boundary -1
        [TestCase("1000")] // upper boundary +1
        [TestCase("01")]
        [TestCase("A12")]
        public void ValidateNumber_InValidNumber_ThrowsException(string? number)
        {
            //arrange
            _address.Number = number;
            //act & assert
            var ex = Assert.Catch(() => _address.ValidateNumber());
            //Contains
            Assert.That(
                ex.Message,
                Does.Contain($"Number {number} must be provided")
                    .Or.Contain(
                        $"Invalid number format: '{number}'. It must be 1 to 3 digits (not starting with 0), optionally followed by a single uppercase letter. Examples: '7', '42B', '123'."
                    )
            );
        }
        #endregion

        #region  Floor validation
        [TestCase(1)] //  lower boundary
        [TestCase(2)]
        [TestCase(50)] // middle value
        [TestCase(98)]
        [TestCase(99)] // upper boundary
        public void ValidateFloor_ValidFloor_DoesNotThrow(int floor)
        {
            //arrange
            _address.Floor = floor;
            //act & assert
            Assert.DoesNotThrow(() => _address.ValidateFloor());
        }

        [Test]
        public void ValidateFloor_ValidFloor_DoesNotThrow_with_St()
        {
            // arrange
            _address.FloorType = FloorType.St;
            Assert.DoesNotThrow(() => _address.ValidateFloor());
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(100)]
        public void ValidateFloor_InValidFloor_ThrowsException(int floor)
        {
            //arrange
            _address.Floor = floor;
            //act & assert
            var ex = Assert.Catch(() => _address.ValidateFloor());
            //Contains
            Assert.That(
                ex.Message,
                Is.EqualTo("FloorNumber must be between 1 and 99. (Parameter 'Floor')")
            );
        }

        [Test]
        [TestCase(FloorType.St, 1)]
        [TestCase(FloorType.None, null)]
        [TestCase((FloorType)999, null)] // Invalid FloorType
        public void ValidateFloor_InValidFloor_ThrowsException_with_St_and_FloorNumber(
            FloorType floorType,
            int? floorNo
        )
        {
            // setting both FloorType as 'st' and FloorNumber.

            // arrange
            _address.FloorType = floorType;
            _address.Floor = floorNo;
            // act & assert
            var ex = Assert.Catch(() => _address.ValidateFloor());
            //Assert.That(ex.Message, Does.StartWith("FloorNumber must be between 1 and 99."));
            switch (ex)
            {
                case ArgumentNullException argNullEx:
                    Assert.That(
                        argNullEx.Message,
                        Does.StartWith("Either FloorType must be 'st' or FloorNumber must be set.")
                    );
                    break;
                case ArgumentException argOutOfRangeEx:
                    Assert.That(
                        argOutOfRangeEx.Message,
                        Does.StartWith("Cannot set both FloorType as 'st' and FloorNumber.")
                    );
                    break;
                default:
                    Assert.Fail("Unexpected exception type: " + ex.GetType());
                    break;
            }
        }
        #endregion

        #region Door validation
        [TestCase(DoorType.Th)]
        [TestCase(DoorType.Mf)]
        [TestCase(DoorType.Tv)]
        public void ValidateDoor_ValidDoor_DoesNotThrow(DoorType doorType)
        {
            // randomly upper and lower case
            //arrange
            var rand = new Random();
            _address.Door =
                rand.Next(2) == 0 ? doorType.ToString().ToUpper() : doorType.ToString().ToLower();
            //act & assert
            Assert.DoesNotThrow(() => _address.ValidateDoor());
        }

        [TestCase("1")]
        [TestCase("2")]
        [TestCase("49")]
        [TestCase("50")]
        [TestCase("2")]
        [TestCase("A-1")]
        [TestCase("A-12")]
        [TestCase("A-123")]
        [TestCase("B1")]
        [TestCase("B12")]
        [TestCase("B0")]
        [TestCase("B123")]
        [TestCase("æ-1")]
        public void ValidateDoor_ValidDoorNumber_DoesNotThrow(string door)
        {
            //arrange
            _address.Door = door;
            //act & assert
            Assert.DoesNotThrow(() => _address.ValidateDoor());
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("0")]
        [TestCase("51")]
        [TestCase("A--1")]
        [TestCase("A-1234")]
        [TestCase("AB-12")]
        [TestCase("A12B")]
        [TestCase("A_12")]
        public void ValidateDoor_InValidDoor_ThrowsException(string? door)
        {
            //arrange
            _address.Door = door;
            //act & assert
            var ex = Assert.Catch(() => _address.ValidateDoor());
            switch (ex)
            {
                case ArgumentNullException argNullEx:
                    Assert.That(argNullEx.Message, Does.StartWith("Door must be provided."));
                    break;
                case ArgumentException argOutOfRangeEx:
                    Assert.That(
                        argOutOfRangeEx.Message,
                        Does.StartWith("Door number must be an integer between 1 and 50.")
                            .Or.StartsWith(
                                $"Door {door} must be either 'th', 'mf', 'tv', a number between 1 and 50, or a valid door format like 'A-1', 'B12', 'C-123', etc."
                            )
                    );
                    break;
            }
        }
        #endregion

        //#region Validate all Method
        //[Test]
        //public void ValidateAll_ValidAddress_DoesNotThrow()
        //{
        //    // arrange
        //   _address = Address.GenerateFakeAddress();
        //    // act & assert
        //    Assert.DoesNotThrow(() => _address.Validate());
        //}

        //#endregion
    }
}

public enum DoorType
{
    None = 0, // by default
    Th = 1,
    Tv = 2,
    Mf = 3,
}
