using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bai_1_6
{
    internal class Program
    {
        interface IThinking
        {
            void thingking_behavior();
        }
        interface IIntelligent
        {
            void intelligent_behavior();
        }
        interface IAbility: IThinking, IIntelligent
        {
        }
        public class Mamal
        {
            public string characteristics;
        }
        public class Whale: Mamal
        {
            public Whale()
            {

            }
        }
        public class Human: Mamal, IAbility
        {
            public Human()
            {

            }
            public void intelligent_behavior()
            {

            }
            public void thingking_behavior()
            {

            }
        }
        static void Main(string[] args)
        {

        }
    }
}
