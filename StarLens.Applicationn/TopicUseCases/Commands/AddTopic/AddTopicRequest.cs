using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.TopicUseCases.Commands.AddTopic
{
    public sealed record AddTopicRequest(string title, string text, int userId) : IRequest<Topic>
    { }
}
