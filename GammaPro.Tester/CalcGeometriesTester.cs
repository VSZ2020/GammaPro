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
            float[][] interpolated_factors = new float[][]
            {
                new float[]{0.1f/*A1*/, 0.2f/*alpha1*/, 0.3f/*alpha2*/, 0.4f/*delta*/}
            };
            float[] attenuation_factors = new float[] { 0.005f};
            IBuildupProcessor buildupProcessor = new Taylor2ExpBuildupProcessor(interpolated_factors);
            IComplexBuildupProcessor complexProcessor = new BroderBuildupProcessor(buildupProcessor, 1);
            ParallelepipedDimensions dims = new ParallelepipedDimensions(1, 1, 1);
            CalculationGeometryInput input = new CalculationGeometryInput(dims, complexProcessor, CancellationToken.None);
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
                        new float[][] {
                            new float[] { 1, 2, 3 } }),
                    1),
                CancellationToken.None);
                new ParallelepipedCalcGeometry(inp, new float[] { 1, 2, 3 });
            });
        }
    }
}
