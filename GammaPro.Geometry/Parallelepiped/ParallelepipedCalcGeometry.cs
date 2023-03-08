using GammaPro.Controller.Buildup;
using GammaPro.Controller.Calculation;
using GammaPro.Controller.Geometry;
using GammaPro.Geometry.Point;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Xml;

namespace GammaPro.Geometry.Parallelepiped
{
    public class ParallelepipedCalcGeometry : ICalculationGeometry
    {
        private readonly CancellationToken token;
        private readonly ParallelepipedDimensions dimensions;
        private readonly IComplexBuildupProcessor? buildupProcessor;
        private readonly IList<IShieldLayer> shieldLayers;
        private readonly bool isIncludeScattering;
        public float[] AttenuationCoefficients { get; private set; }

        public double CalculateFluxRate()
        {
            return CalculateFluxRate(new Point3D() { X = 0, Y = 0, Z = 0 });
        }
        public double CalculateFluxRate(Point3D destinationPoint)
        {
            double integralSum = 0;
            return integralSum / (4.0 * Math.PI);
        }

        public ParallelepipedCalcGeometry(CalculationGeometryInput calculationInput, float[] attenuation_factors)
        {
            if (calculationInput is null)
                throw new ArgumentNullException("The calculation input is NULL");
            if (attenuation_factors is null)
                throw new ArgumentNullException("Parallelepiped geometry. Attenuation coefficients array is NULL!");
            if (calculationInput.Dimensions is null)
                throw new ArgumentNullException("Calculation dimensions object is NULL");
            if (calculationInput.Dimensions is not ParallelepipedDimensions)
                throw new ArgumentException($"The input dimensions type {calculationInput.Dimensions.GetType()} is not appropriate for this Object {this.GetType()}");
            if (calculationInput.ShieldLayers is null)
                throw new ArgumentNullException("Shield layers list is NULL");
            
            AttenuationCoefficients = attenuation_factors;
            this.dimensions = calculationInput.Dimensions as ParallelepipedDimensions;
            this.shieldLayers = calculationInput.ShieldLayers;
            this.token = calculationInput.Token;

            //Если присутствует реализация интерфейса, то необходим расчет фактора накопления, иначе - не требуется
            if (calculationInput.BuildupComplexProcessor is not null)
            {
                //Флаг учета фактора накопления
                isIncludeScattering = true;
                this.buildupProcessor = calculationInput.BuildupComplexProcessor;
            }
            else
                isIncludeScattering = false;
            
        }

        /// <summary>
        /// Заменяет уже имеющийся массив коэффициентов ослабления. Размеры массивов до и после должны совпадать
        /// </summary>
        /// <param name="newCoefficients">Массив новых коэффициентов</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Исключение при несоответствии размеров массивов до и после</exception>
        /// <exception cref="ArgumentNullException">Исключение при пустой ссылке на новый массив</exception>
        public ICalculationGeometry UpdateAttenuationFactors(float[] new_factors)
        {
            if (new_factors != null)
                if (new_factors.Length == AttenuationCoefficients.Length)
                    AttenuationCoefficients = new_factors;
                else
                    throw new ArgumentOutOfRangeException("New coefficients array size is not equal to the old coefficients array size!");
            else
                throw new ArgumentNullException("New coefficients array is NULL!");
            return this;
        }

    }
}
