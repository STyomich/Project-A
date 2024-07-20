using Moq;
using MediatR;

public class TestFixture
{
    public Mock<IMediator> MediatorMock { get; }

    public TestFixture()
    {
        MediatorMock = new Mock<IMediator>();
    }
}