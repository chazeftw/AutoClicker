using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClicker
{
    public class ClickManager
    {
        Random rand;
        MouseOperations.MousePoint startingPoint;

        public ClickManager()
        {
            rand = new Random();
            startingPoint = MouseOperations.GetCursorPosition();
        }

        public void SpamClick(MouseOperations.MouseEventFlags button)
        {
            MouseOperations.MouseEvent(button);
        }
        
        public void IntervalClick(MouseOperations.MouseEventFlags button, int delayInMs)
        {
            MouseOperations.MouseEvent(button);
            System.Threading.Thread.Sleep(delayInMs);
        }

        public void RandomIntervalClick(MouseOperations.MouseEventFlags button, int firstIntervalInMs, int secondIntervalInMs)
        {
            MouseOperations.MouseEvent(button);
            System.Threading.Thread.Sleep(rand.Next(firstIntervalInMs, secondIntervalInMs));
        }

        public void PrintMousePos()
        {
            Console.WriteLine(MouseOperations.GetCursorPosition().X + " " + MouseOperations.GetCursorPosition().Y);
        }

        public void SimulateRandomMouseMovement(int pixelRange, int delayInMs)
        {
            int randomX = rand.Next(pixelRange * -1, pixelRange);
            int randomY = rand.Next(pixelRange * -1, pixelRange);

            MouseOperations.SetCursorPosition(randomX+startingPoint.X, randomY+startingPoint.Y);

            System.Threading.Thread.Sleep(delayInMs);

        }

    }
}
