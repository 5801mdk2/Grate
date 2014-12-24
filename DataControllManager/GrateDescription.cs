using System;

namespace DataControllManager
{
    public class GrateDiscription
    {
        /// <summary>
        /// Поле, описывающее параметр высоты фундамента
        /// </summary>
        private double _foundationHeight;

        /// <summary>
        /// Свойство, реализующее поле _foundationHeight
        /// </summary>
        public double FoundationHeight
        {
            get { return _foundationHeight; }
            set
            {
                if ((value <= 20) && (value >= 15))
                {
                    _foundationHeight = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(@"Допустимое значение в пределах от 15 до 20");
                }
            }
        }

        /// <summary>
        /// Поле, описывающее параметр ширины фундамента
        /// </summary>
        private double _foundationWidth;

        /// <summary>
        /// Свойство, реализующее поле _foundationWidth
        /// </summary>
        public double FoundationWidth
        {
            get { return _foundationWidth; }
            set
            {
                if ((value <= 80) && (value >= 60))
                {
                    if (value >= 4*_foundationHeight)
                    {
                        _foundationWidth = value;
                    }
                    else
                    {
                        throw new ArgumentException(@"Допустимое значение в пределах от 60 до 80");
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException(@"Введенные данные не соотносятся, т.к. параметр ширины фундамента должен быть в 4 раза больше параметра высоты фундамента.");
                   
                }
            }
        }

        /// <summary>
        /// Поле, описывающее параметр длины фундамента
        /// </summary>
        private double _foundationLength;

        /// <summary>
        /// Свойство, реализующее поле _foundationLength
        /// </summary>
        public double FoundationLength
        {
            get { return _foundationLength; }
            set
            {
                if ((value <= 60) && (value >= 45))
                {
                    if (value >= 3*_foundationHeight)
                    {
                        _foundationLength = value;
                    }
                    else
                    {
                        throw new ArgumentException(@"Введенные данные не соотносятся, т.к. параметр длины фундамента должен быть в 3 раза больше параметра высоты фундамента.");
                        
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException(@"Допустимое значение в пределах от 45 до 60");
                    
                }
            }
        }

        /// <summary>
        /// Поле, описывающее параметр высоты надфундаментной плиты
        /// </summary>
        private double _foundationPlateHeight;

        /// <summary>
        /// Свойство, реализующее поле _foundationPlateHeight
        /// </summary>
        public double FoundationPlateHeight
        {
            get { return _foundationPlateHeight; }
            set
            {
                if ((value <= 10) && (value >= 7.5))
                {
                    if (value <= _foundationHeight/2)
                    {
                        _foundationPlateHeight = value;
                    }
                    else
                    {
                        throw new ArgumentException(@"Допустимое значение в пределах от 7,5 до 10");
                       
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException(@"Введенные данные не соотносятся, т.к. параметр высоты надфундаментной плиты должен быть в 2 раза меньше параметра высоты фундамента.");
                    
                }
            }
        }

        /// <summary>
        /// Поле, описывающее параметр ширины надфундаментной плиты
        /// </summary>
        private double _foundationPlateWidth;

        /// <summary>
        /// Свойство, реализующее поле _foundationPlateWidth
        /// </summary>
        public double FoundationPlateWidth
        {
            get { return _foundationPlateWidth; }
            set
            {
                if ((value <= 100) && (value >= 80))
                {
                    if (value >= _foundationWidth + 20)
                    {
                        _foundationPlateWidth = value;
                    }
                    else
                    {
                        throw new ArgumentException(@"Допустимое значение в пределах от 80 до 100");
                       
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException(@"Введенные данные не соотносятся, т.к. параметр длины надфундаментной плиты должен быть больше параметра длины фундамента на 20.");
                    
                }
            }
        }

        /// <summary>
        /// Поле, описывающее параметр длины печного блока
        /// </summary>
        private double _foundationPlateLength;

        /// <summary>
        /// Свойство, реализующее поле _foundationPlateLength
        /// </summary>
        public double FoundationPlateLength
        {
            get { return _foundationPlateLength; }
            set
            {
                if ((value <= 80) && (value >= 65))
                {
                    if (value >= _foundationLength + 20)
                    {
                        _foundationPlateLength = value;
                    }
                    else
                    {
                        throw new ArgumentException(@"Введенные данные не соотносятся, т.к. параметр длины надфундаментной плиты должен быть больше параметра длины фундамента на 20.");
                 
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException(@"Допустимое значение в пределах от 65 до 80");
                    
                }
            }
        }

        /// <summary>
        /// Поле, описывающее параметр высоты печного блока
        /// </summary>
        private double _furnaceBlockHeight;

        /// <summary>
        /// Свойство, реализующее поле _furnaceBlockHeight
        /// </summary>
        public double FurnaceBlockHeight
        {
            get { return _furnaceBlockHeight; }
            set
            {
                if ((value <= 50) && (value >= 40))
                {
                    _furnaceBlockHeight = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(@"Допустимое значение в пределах от 40 до 50");
                  
                }
            }
        }

        /// <summary>
        /// Поле, описывающее параметр ширины печного блока
        /// </summary>
        private double _furnaceBlockWidth;

        /// <summary>
        /// Свойство, реализующее поле _furnaceBlockWidth
        /// </summary>
        public double FurnaceBlockWidth
        {
            get { return _furnaceBlockWidth; }
            set
            {
                if ((value <= 70) && (value >= 50))
                {
                    if (value <= _foundationWidth - 10)
                    {
                        _furnaceBlockWidth = value;
                    }
                    else
                    {
                        throw new ArgumentException(@"Введенные данные не соотносятся, т.к. параметр ширины печного блока должен быть меньше ширины фундамента на 10.");
                      
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException(@"Допустимое значение в пределах от 50 до 70");
                    
                }
            }
        }

        /// <summary>
        /// Поле, описывающее параметр длины печного блока
        /// </summary>
        private double _furnaceBlockLength;

        /// <summary>
        /// Свойство, реализующее поле _furnaceBlockLength
        /// </summary>
        public double FurnaceBlockLength
        {
            get { return _furnaceBlockLength; }
            set
            {
                if ((value <= 55) && (value >= 40))
                {
                    if (value <= _foundationLength - 5)
                    {
                        _furnaceBlockLength = value;
                    }
                    else
                    {
                        throw new ArgumentException(@"Введенные данные не соотносятся, т.к. параметр длины печного блока должен быть меньше длины фундамента на 5.");
                     
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException(@"Допустимое значение в пределах от 40 до 50");
                  
                }
            }
        }

        /// <summary>
        /// Поле, описывающее параметр ширины поддувала
        /// </summary>
        public double AshpitWidth;

        /// <summary>
        /// Поле, описывающее параметр высоты поддувала
        /// </summary>
        public double AshpitHeight;

        /// <summary>
        /// Поле, описывающее параметр длины поддувала
        /// </summary>
        public double AshpitLength;

        /// <summary>
        /// Поле, описывающее параметр длины поддувала
        /// </summary>
        public double BurnerHeight;

        /// <summary>
        /// Поле, описывающее параметр ширины топки
        /// </summary>
        public double BurnerWidth;

        /// <summary>
        /// Поле, описывающее параметр длины топки
        /// </summary>
        public double BurnerLength;

        /// <summary>
        /// Поле, описывающее параметр высоты дымоходного отверстия
        /// </summary>
        public double ChimneyHeight;

        /// <summary>
        /// Поле, описывающее параметр ширины дымоходного отверстия
        /// </summary>
        public double ChimneyWidth;

        //доп. параметры(дополнительное задание)
        /// <summary>
        /// Поле, описывающее параметр высоты трубы
        /// </summary>
        private double _pipeHeight;

        /// <summary>
        /// Свойство, реализующее поле _pipeHeight
        /// </summary>
        public double PipeHeight //высота трубы
        {
            get { return _pipeHeight; }
            set
            {
                if ((value <= 100) && (value >= 80))
                {
                    _pipeHeight = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(@"Допустимое значение в пределах от 80 до 100");
              
                }
            }
        }

        /// <summary>
        /// Поле, описывающее высоту огранки трубы
        /// </summary>
        private double _mantelHeight;
        /// <summary>
        /// Свойство, реализующее поле _mantelHeight
        /// </summary>
        public double MantelHeight
        {
            get { return _mantelHeight; }
            set
            {
                if ((value <= 30) && (value >= 15))
                {
                    _mantelHeight = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(@"Допустимое значение в пределах от 15 до 30");
                   
                }
            }
        }
    }
}
