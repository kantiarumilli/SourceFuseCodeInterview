using AcmeCorp.ContactInfo.Abstract.Facade;
using AcmeCorp.ContactInfo.Abstract.Services;
using AcmeCorp.ContactInfo.Entities.BO;
using AcmeCorp.ContactInfo.Entities.DBO;
using AcmeCorp.ContactInfo.Facade;
using AutoMapper;
using Moq;

namespace AcmeCorp.ContactInfo.Facade.Tests
{
    public class Tests
    {
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            var mapperConfig = new MapperConfiguration((cfg) =>
            {
                cfg.CreateMap<ContactBO, ContactDBO>().ReverseMap();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Test]
        public void CreateContactAsyncReturnsEmptyStringIfIdHasValue()
        {
            var sut = new ContactFacade(null, null);
            var value = sut.CreateContactAsync(new Entities.BO.ContactBO { Id = "abcd1234" }).Result;

            Assert.IsEmpty(value);
        }

        [Test]
        public void CreateContactAsyncCallsService()
        {
            var expected = "abcd1234";
            var mockDBService = new Mock<IContactDBService>();
            mockDBService.Setup(m => m.CreateContactAsync(It.IsAny<Entities.DBO.ContactDBO>())).Returns(Task.FromResult(expected)).Verifiable();

            var sut = new ContactFacade(mockDBService.Object, _mapper);
            var value = sut.CreateContactAsync(new ContactBO()).Result;

            Assert.AreEqual(expected, value);
        }

        [Test]
        public void DeleteContactAsyncDoesNotCallServiceIfIdIsEmpty()
        {
            var mockDBService = new Mock<IContactDBService>();
            var sut = new ContactFacade(null, null);
            sut.DeleteContactAsync(string.Empty).Wait();

            mockDBService.VerifyNoOtherCalls();
        }

        [Test]
        public void DeleteContactAsyncCallsService()
        {
            var expected = "abcd1234";
            var mockDBService = new Mock<IContactDBService>();
            mockDBService.Setup(m => m.DeleteContactAsync(expected)).Returns(Task.CompletedTask).Verifiable();

            var sut = new ContactFacade(mockDBService.Object, _mapper);
            sut.DeleteContactAsync(expected).Wait();

            mockDBService.VerifyAll();
        }

        [Test]
        public void GetContactReturnsNullForEmptyString()
        {
            var mockDBService = new Mock<IContactDBService>();
            var sut = new ContactFacade(null, null);
            var value = sut.GetContactAsync(string.Empty).Result;

            Assert.IsNull(value);
            mockDBService.VerifyNoOtherCalls();
        }

        [Test]
        public void GetContactCallServiceForNonEmptyString()
        {
            var expected = new ContactDBO { Id = "abcd1234" };
            var mockDBService = new Mock<IContactDBService>();
            mockDBService.Setup(m => m.GetContactAsync(expected.Id)).Returns(Task.FromResult(expected)).Verifiable();

            var sut = new ContactFacade(mockDBService.Object, _mapper);
            var value = sut.GetContactAsync(expected.Id).Result;

            Assert.AreEqual(expected.Id, value.Id);
            mockDBService.VerifyAll();
        }

        [Test]
        public void GetContactsCallsServiceForValidValues()
        {
            var expected = new List<ContactDBO> { new ContactDBO { Id = "abcd1234" } };
            var mockDBService = new Mock<IContactDBService>();
            mockDBService.Setup(m => m.GetContacts(1, 1)).Returns(expected).Verifiable();

            var sut = new ContactFacade(mockDBService.Object, _mapper);
            var value = sut.GetContacts(1, 1);

            Assert.AreEqual(expected.Count, value.Count());
            Assert.AreEqual(expected[0].Id, value.ElementAt(0).Id);
            mockDBService.VerifyAll();
        }

        [Test]
        public void GetContactsReturnsNullForWrongValues()
        {
            var mockDBService = new Mock<IContactDBService>();
            var sut = new ContactFacade(null, null);

            var value = sut.GetContacts(0, 100);
            Assert.IsNull(value);

            value = sut.GetContacts(501, 5);
            Assert.IsNull(value);

            value = sut.GetContacts(5, 0);
            Assert.IsNull(value);


            mockDBService.VerifyNoOtherCalls();
        }

        [Test]
        public void UpdateContactCallsServiceForValidValues()
        {
            var mockDBService = new Mock<IContactDBService>();
            mockDBService.Setup(m => m.UpdateContactAsync(It.IsAny<ContactDBO>())).Returns(Task.CompletedTask).Verifiable();

            var sut = new ContactFacade(mockDBService.Object, _mapper);
            var value = sut.UpdateContactAsync(new ContactBO { Id = "abcd" });

            mockDBService.VerifyAll();
        }

        [Test]
        public void UpdateContactsReturnsNullForWrongValues()
        {
            var mockDBService = new Mock<IContactDBService>();
            var sut = new ContactFacade(null, null);

            var value = sut.UpdateContactAsync(null);

            value = sut.UpdateContactAsync(new ContactBO());

            mockDBService.VerifyNoOtherCalls();
        }
    }
}