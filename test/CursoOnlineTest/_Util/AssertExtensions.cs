using System;
using Microsoft.VisualBasic;
using Xunit;

namespace CursoOnline.DominioTest._Util
{
    public static class AssertExtensions
    {
        public static void WithMessage(this ArgumentException exception, string mensagem)
        {
            if(exception.Message.Equals(mensagem))
                Assert.True(true);
            else
                Assert.False(true);
                
            
        }

    }
}