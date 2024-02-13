/*Challenge link:https://www.codewars.com/kata/57102bbfd860a3369300089c/train/csharp
Question:The year is 2070 and intelligent connected machines have replaced humans in most things. There are still a few critical jobs for mankind including machine software developer, for writing and maintaining the AI software, and machine forward deployed engineer for controlling the intelligent machines in the field. Lorimar is a forward deployed machine engineer and at any given time he controls thousands of BOT robots through real time interfaces and intelligent automation software. These interfaces are directly connected to his own brain so at all times his mind and the robots are one. They are pre-trained to think on their own but on occasion the human will direct the robot to perform a task.

There is an issue with the ultrasonic sensor data feed from BOT785 currently connected to Lorimar through a real time interface. The data feed from sensor five should be a series of floats representing the relative distance of objects within BOT785's path. The sensor error log has been saved for triage and Lorimar needs to search through the data to determine the mean and standard deviation of the distance variables.

You will be given a list of tuples extracted from the sensor logs:

sensor_data = [('Distance:', 116.28, 'Meters', 'Sensor 5 malfunction =>lorimar'), ('Distance:', 117.1, 'Meters', 'Sensor 5 malfunction =>lorimar'), ('Distance:', 123.96, 'Meters', 'Sensor 5 malfunction =>lorimar'), ('Distance:', 117.17, 'Meters', 'Sensor 5 malfunction =>lorimar')]
Return a tuple with the mean and standard deviation of the distance variables rounded to four decimal places. The variance should be computed using the formula for samples (dividing by N-1).

|Mean| |Standard Deviation|

(118.6275, 3.5779)
Hint (http://math.stackexchange.com/questions/15098/sample-standard-deviation-vs-population-standard-deviation)

Please also try the other Kata in this series..

AD2070:Help Lorimar troubleshoot his robots-Search and Disable
*/

//***************Solution********************//root mean square
using System;
using System.Linq;

public class Kata{
  public static double[] SensorAnalysis(object[][] sensorData){
    var firstItem = sensorData.Select(x => (double)x[1]);
    var mean = firstItem.Average();
    var standardDeviation = Math.Sqrt(sensorData.Select(x => Math.Pow((double) x[1] - mean, 2))
                                .Sum() / (sensorData.Length - 1));
    
    return new double[] {Math.Round(mean, 4), Math.Round(standardDeviation, 4)};
  }
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    { 
      var sensorData1 = new [] { new object[] { "Distance:", 116.28, "Meters", "Sensor 5 malfunction =>lorimar" }, new object[] { "Distance:", 117.1, "Meters", "Sensor 5 malfunction =>lorimar" }, new object[] { "Distance:", 123.96, "Meters", "Sensor 5 malfunction =>lorimar" }, new object[] { "Distance:", 117.17, "Meters", "Sensor 5 malfunction =>lorimar" }};
      Assert.AreEqual(Kata.SensorAnalysis(sensorData1), new double[] { 118.6275, 3.5779 });

      var sensorData2 = new [] { new object[] { "Distance:", 295.68, "Meters", "Sensor 5 malfunction =>lorimar" }, new object[] { "Distance:", 294.78, "Meters", "Sensor 5 malfunction =>lorimar" }, new object[] { "Distance:", 298.21, "Meters", "Sensor 5 malfunction =>lorimar" }, new object[] { "Distance:", 294.84, "Meters", "Sensor 5 malfunction =>lorimar"}, new object[] { "Distance:", 296.54, "Meters", "Sensor 5 malfunction =>lorimar"}, new object[] { "Distance:", 133.84, "Meters", "Sensor 5 malfunction =>lorimar"}, new object[] { "Distance:", 294.41, "Meters", "Sensor 5 malfunction =>lorimar"}, new object[] { "Distance:", 294.82, "Meters", "Sensor 5 malfunction =>lorimar"}, new object[] { "Distance:", 134.61, "Meters", "Sensor 5 malfunction =>lorimar"}, new object[] { "Distance:", 294.86, "Meters", "Sensor 5 malfunction =>lorimar"}, new object[] { "Distance:", 170.88, "Meters", "Sensor 5 malfunction =>lorimar"}, new object[] { "Distance:", 170.87, "Meters", "Sensor 5 malfunction =>lorimar"}, new object[] { "Distance:", 170.47, "Meters", "Sensor 5 malfunction =>lorimar"}, new object[] { "Distance:", 135.5, "Meters", "Sensor 5 malfunction =>lorimar"}, new object[] { "Distance:", 170.9, "Meters", "Sensor 5 malfunction =>lorimar"}, new object[] { "Distance:", 170.08, "Meters", "Sensor 5 malfunction =>lorimar"}, new object[] { "Distance:", 171.36, "Meters", "Sensor 5 malfunction =>lorimar"}, new object[] { "Distance:", 170.08, "Meters", "Sensor 5 malfunction =>lorimar"}, new object[] { "Distance:", 170.92, "Meters", "Sensor 5 malfunction =>lorimar" }, new object[] { "Distance:", 170.88, "Meters", "Sensor 5 malfunction =>lorimar" }};
      Assert.AreEqual(Kata.SensorAnalysis(sensorData2), new double[] { 215.2265, 68.4014 });
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      Func<object[][], double[]> mySensorAnalysis = delegate (object[][] sensorData)
      {
        var values = sensorData.Select(a => (double)a[1]);
        var mean = values.Aggregate((a,b) => a + b) / values.Count();

        var variance = values.Select(a => (mean - a) * (mean - a)).Aggregate((a,b) => a + b) / (values.Count()-1);

        return new double[] { Math.Round(mean, 4), Math.Round(Math.Sqrt(variance), 4) };
      };

      for (var i=0;i<40;i++)
      {
        var length = rand.Next(1,10);
        var m = rand.Next(100,30000);
        var d = rand.Next(500,10000);
        var s = Enumerable.Range(0,length).Select(a => new object[] { "Distance:", ((double)rand.Next(m-d,m+d))/100, "Meters", "Sensor 5 malfunction =>lorimar" }).ToArray();

        Assert.AreEqual(mySensorAnalysis(s), Kata.SensorAnalysis(s), "It should work for random inputs too");
      }
    }
  }
}
