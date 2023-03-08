using GammaPro.Utils.RadiationFactors.Buildup;
namespace GammaPro.Tester
{
    public class BuildupTesters
    {
        [Fact]
        public void TaylorBuildupTest()
        {
            float[][] arguments = new float[][]
            {
                new float[]
                {
                    0.132f,     //A1
                    -0.54f,     //alpha1
                    -0.232f,    //alpha2
                    0.982f      //barrier factor
                }
        };
            IBuildupProcessor taylor_processor = new Taylor2ExpBuildupProcessor(arguments);
            double buildup = taylor_processor.GetBuildupFactor(0.44, 0, true);
            Assert.Equal(1.128688, buildup, 1E-6);
        }
        public void JapanBuildupTest_1()
        {
            float[][] arguments = new float[][]
            {
               new float[]
               {
                    0.132f,     //a
                    0.54f,      //b
                    0.232f,     //c
                    0.982f,     //d
                    0.62f,      //xi
                    0.833f      //barrier factor
               }
        };
            IBuildupProcessor japan_processor = new JapanBuildupProcessor(arguments);
            double buildup = japan_processor.GetBuildupFactor(0.44, 0, true);
            Assert.Equal(0, buildup, 1E-6);
        }
    }
}