using GammaPro.Controller.Buildup;
using GammaPro.Controller.Calculation;
using GammaPro.Controller.Geometry;
using GammaPro.Geometry;
using GammaPro.Geometry.Cylinder;
using GammaPro.Geometry.Parallelepiped;
using GammaPro.Utils.RadiationFactors.Buildup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Tester
{

    public class CalcGeometriesTester
    {
        [Fact]
        public void TestParallelepipedGeometry()
        {
            float[] attenuation_factors = new float[] { 0.005f};
            IBuildupProcessor buildupProcessor = new Taylor2ExpBuildupProcessor(
                new BaseBuildupCoefficientsProvider(BuildupTesters.GetRandomCoefficientsByLayer(1, BuildupTesters.GetRandomTaylorCoefficients)));
            IComplexBuildupProcessor complexProcessor = new BroderBuildupProcessor(buildupProcessor, 1);
            ParallelepipedDimensions dims = new ParallelepipedDimensions(1, 1, 1);
            CalculationGeometryInput input = new CalculationGeometryInput(dims, complexProcessor, new List<ShieldLayer>(),CancellationToken.None);
            ICalculationGeometry geometry = new ParallelepipedCalcGeometry(input, attenuation_factors);
            double result = geometry.CalculateFluxRate();
            //TODO: finish test
        }
        /// <summary>
        /// Проверка того, что при передаче объекту расчетчика неправильного класса с размерами, выпадет исключение
        /// </summary>
        [Fact]
        public void TestIncorrectDimensionsTypeInjection()
        {
            
            Assert.Throws<ArgumentException>(() =>
            {
                var inp = new CalculationGeometryInput(
                new CylinderDimensions(1, 1),
                new BroderBuildupProcessor(
                    new Taylor2ExpBuildupProcessor(
                        new BaseBuildupCoefficientsProvider(
                            BuildupTesters.GetRandomCoefficientsByLayer(1,BuildupTesters.GetRandomTaylorCoefficients))),
                1),
                new List<ShieldLayer>(),
                CancellationToken.None);
                new ParallelepipedCalcGeometry(inp, new float[] { 1, 2, 3 });
            });
        }
    }
}
