using System.Threading.Tasks;
using Moq;
using School.Application.Students;
using School.Domain.Students;
using Xunit;

namespace School.Test
{
    public class EnrollStudentTest
    {
        [Fact]
        public async Task It_Should_Add_The_Student()
        {
            var studentRepository = new Mock<IStudentRepository>();

            var hash = new Mock<IHash>();

            hash.Setup(it => it.Make(It.IsAny<string>())).ReturnsAsync("hash");

            var enroll = new EnrollStudent(studentRepository.Object, hash.Object);

            var data = new EnrollStudentDto("11100011100", "Frank", "frank@email.com", "123456");

            await enroll.Execute(data);

            studentRepository.Verify(it => it.Add(It.IsAny<Student>()), Times.Once);
        }
    }
}
