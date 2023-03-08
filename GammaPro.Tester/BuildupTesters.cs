using GammaPro.Utils.RadiationFactors.Buildup;
namespace GammaPro.Tester
{
    public class BuildupTesters
    {
        [Fact]
        public void TaylorBuildupTest()
        {
            IBuildupCoefficientsProvider provider = new BaseBuildupCoefficientsProvider(
                GetRandomCoefficientsByLayer
                (
                    (new Random()).Next(1, 10),
                    GetRandomTaylorCoefficients
                )
            );
            IBuildupProcessor taylor_processor = new Taylor2ExpBuildupProcessor(provider);
            double buildup = taylor_processor.GetBuildupFactor(0.44, 0, true);
            Assert.True(buildup >= 1.0);
        }

        [Fact]
        public void JapanBuildupTest_1()
        {
            IBuildupCoefficientsProvider provider = new BaseBuildupCoefficientsProvider(
                GetRandomCoefficientsByLayer
                (
                    (new Random()).Next(1,10), 
                    GetRandomJapanCoefficients
                )
            );
            float ud = 0.44f;
            IBuildupProcessor japan_processor = new JapanBuildupProcessor(provider);
            double buildup = japan_processor.GetBuildupFactor(ud, 0, true);
            Assert.True(buildup >= 1.0);
        }

        public static float[][] GetRandomCoefficientsByLayer(int layers_count, Func<float[]> coeffsGenerator)
        {
            float[][] coeffs = new float[layers_count][];
            for (int i = 0; i < layers_count; i++)
                coeffs[i] = coeffsGenerator.Invoke();
            return coeffs;
        }

        public static float[] GetRandomTaylorCoefficients()
        {
            return new float[]
            {
                GetRandomInRange(0.2f,30f),     //A1
                GetRandomInRange(-0.005f,0.6f), //alpha1
                GetRandomInRange(0, 0.2f),      //alpha2
                GetRandomInRange(0.7f, 1f)      //Barrier
            };
        }
        public static float[] GetRandomJapanCoefficients()
        {
            return new float[]
            {
                GetRandomInRange(0.01f,0.5f),     //a
                GetRandomInRange(0.01f,0.5f),     //b
                GetRandomInRange(0.01f,0.5f),     //c
                GetRandomInRange(0.01f,0.5f),     //d
                GetRandomInRange(0.01f,0.5f),     //xi
                GetRandomInRange(0.01f,0.5f),     //barrier
            };
        }
        public static float GetRandomInRange(float min, float max)
        {
            Random rnd = new Random();
            return min + rnd.NextSingle() * (max - min);
        }
    }
}