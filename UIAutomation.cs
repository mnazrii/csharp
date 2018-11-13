using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace ConsoleApplication1
{
    class Program
    {
        private static AutomationElement _resultTextBoxAutomationElement;

        static void Main(string[] args)
        {



            AutomationElement _calculatorAutomationElement;

            Thread.Sleep(10000);

            PropertyCondition findWindow = new PropertyCondition(AutomationElement.ClassNameProperty, "RegEdit_RegEdit");
            AutomationElement window = AutomationElement.RootElement.FindFirst(TreeScope.Children, findWindow);

            PropertyCondition findWindowapplist = new PropertyCondition(AutomationElement.ClassNameProperty, "Shell_Flyout");
            AutomationElement window2 = AutomationElement.RootElement.FindFirst(TreeScope.Children, findWindowapplist);


            int ct = 0;
            do
            {
                _calculatorAutomationElement = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, 
            new AndCondition(
                new PropertyCondition(AutomationElement.ClassNameProperty,"AppListTileElement"),
                new PropertyCondition(AutomationElement.NameProperty,"Registry Editor"),
                new PropertyCondition(AutomationElement.FrameworkIdProperty,"DirectUI")));

                InvokePattern invokePattern = _calculatorAutomationElement.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                invokePattern.Invoke();


                ++ct;
                Thread.Sleep(100);
            }
            while (_calculatorAutomationElement == null && ct < 50);

            
            
        }
    }
}
