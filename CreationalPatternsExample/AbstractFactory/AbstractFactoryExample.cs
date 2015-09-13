using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{

    abstract class GuiFactory
    {
        public static GuiFactory getFactory(int code)
        {
            int sys = code;
            if (sys == 0)
            {
                return (new WinFactory());
            }
            else
            {
                return (new OSXFactory());
            }
        }
        public abstract Button createButton();
    }

    class WinFactory : GuiFactory
    {
        public override Button createButton()
        {
            return (new WinButton());
        }
    }

    class OSXFactory : GuiFactory
    {
        public override Button createButton()
        {
            return (new OSXButton());
        }
    }

    abstract class Button
    {
        public string caption;
        public abstract void paint();
    }

    class WinButton : Button
    {
        public override void paint()
        {
            Console.WriteLine("I'm a WinButton: " + caption);
        }
    }

    class OSXButton : Button
    {
        public override void paint()
        {
            Console.WriteLine("I'm a OSXButton: " + caption);
        }
    }

    class AbstractFactoryExample
    {
        static void Main(string[] args)
        {
            GuiFactory aFactory = GuiFactory.getFactory(0);
            Button aButton = aFactory.createButton();
            aButton.caption = "Play";
            aButton.paint();
        }
        //output is
        //I'm a WinButton: Play
        //or
        //I'm a OSXButton: Play
    }
}
