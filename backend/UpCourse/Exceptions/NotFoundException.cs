using System;

namespace UpCourse.Exceptions
{
    public class NotFoundException:Exception
    {
        public NotFoundException(string message = "Element was not found"): base(message)
        {
            
        }
    }
}