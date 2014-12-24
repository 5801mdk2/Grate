using Kompas6API5;
using Kompas6Constants3D;


namespace Model
{
   public static class GrateBuilder
    {
      /* private static object _part;

       /// <summary>
        /// Вырезать объект
        /// </summary>
        /// <param name="_sketch">Ссылка на эскиз объекта</param>
        /// <param name="length">Глубина вырезания</param>
        internal static void CutObject(ksEntity _sketch, double length, bool direction, bool angel)
        {
            //Получаем интерфейс объекта "операция вырезание выдавливанием"
            var entityCutExtrusion = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            //Получаем интерфейс параметров операции
            var cutExtrusionDefinition = (ksCutExtrusionDefinition)entityCutExtrusion.GetDefinition();
            //Вычетание элементов
            cutExtrusionDefinition.cut = true;
            if (angel)
            {
                if (direction)
                {
                    //Прямое направление
                    cutExtrusionDefinition.directionType = (short)Direction_Type.dtNormal;
                    //Устанавливаем параметры выдавливания
                    cutExtrusionDefinition.SetSideParam(true, (short)End_Type.etBlind, length);
                }
                else
                {
                    //Прямое направление
                    cutExtrusionDefinition.directionType = (short)Direction_Type.dtReverse;
                    //Устанавливаем параметры выдавливания
                    cutExtrusionDefinition.SetSideParam(false, (short)End_Type.etBlind, length);
                }
            }
            else
            {
                //Прямое направление
                cutExtrusionDefinition.directionType = (short)Direction_Type.dtNormal;
                //Устанавливаем параметры выдавливания
                cutExtrusionDefinition.SetSideParam(true, (short)End_Type.etBlind, length, 27, false);
            }
            //Устанавливаем экиз операции
            cutExtrusionDefinition.SetSketch(_sketch);
            //Создаем операцию вырезания выдавливанием
            entityCutExtrusion.Create();
        }

        /// <summary>
        /// Выдавливание основания
        /// </summary>
        internal static void PressBase(double _depth)
        {
            var entityExtr = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_baseExtrusion);
            var sketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
            var definitionSketch = (ksSketchDefinition)_baseSketch.GetDefinition();
            if (entityExtr != null)
            {
                // интерфейс свойств базовой операции выдавливания
                var extrusionDef = (ksBaseExtrusionDefinition)entityExtr.GetDefinition(); // интерфейс базовой операции выдавливания

                if (extrusionDef != null)
                {
                    extrusionDef.SetSideParam(true, (short)End_Type.etBlind, _depth);	// прямое направление, строго на глубину

                    extrusionDef.SetSketch(_baseSketch);	// Эскиз операции выдавливания
                    entityExtr.Create();				// Создать операцию

                    entityExtr.Update();               // Обновить параметры операции выдавливания
                }
            }

            definitionSketch.EndEdit();    // Завершение редактирования эскиза
            sketch.Update();               // Обновление параметров эскиза
        }

        /// <summary>
        /// Выдавливание приклеиванием к смещенной плоскости
        /// </summary>
        /// <param name="_sketch">Эскиз</param>
        /// <param name="length">Глубина выдавливания</param>
        internal static void BossExtrusion(ksEntity _sketch, double length)
        {
            // Получаем интерфейс объекта "Операция выдавливания"
            ksEntity _bossExtrusion = _part.NewEntity((short)Obj3dType.o3d_bossExtrusion);

            // Получаем интерфейс параметров операции выдавливания
            ksBossExtrusionDefinition _bossExtrDefinition = _bossExtrusion.GetDefinition();

            // Устанавливаем параметры операци выдавливания
            _bossExtrDefinition.SetSideParam(true, (short)End_Type.etBlind, length); // прямое направление, строго на глубину, глубина

            // Устанавливаем эскиз операции выдавливания
            _bossExtrDefinition.SetSketch(_sketch);

            // Выдавливаем
            _bossExtrusion.Create();

        }
    /*   
      static  private void CreateBaseForFoundation()
        {

        }
     

      static  private void CreateAshipt()
        {

        }
      static  private void CreateFoundation()
        {

        }
      static  private void CreateBaseForFoundationPlate()
        {

        }
      static  private void PressBase()
        {

        }


      static  private void CreateFoundationPlate()
        {

        }
      static  private void CutChimney()
        {

        }

      static  private void CutBurnert()
        {

        }

      static  private void CreateRounding()
        {

        }

    

       static  void CreateFurnfaceBlock()
        {

        }


     

       internal static void BuildFoundation(double p1, double p2)
       {
          
       }

       internal static void BuildFoundationPlate()
       {
          
       }

       internal static void BuildFurnaceBlock()
       {
          
       }

       internal static void BuildFoundation(double p1, double p2, double p3)
       {
       }

       internal static void BuildFoundation(double p1, double p2, double p3, double p4)
       {
           
       }

       internal static void BuildFoundationPlate(double p1, double p2, double p3)
       {
           
       }

       internal static void BuildFurnaceBlock(double p1, double p2, double p3)
       {
           
       }

     

        void BuildFurnaceBlock(double p1, double p2, double p3, double p4, double p5, double p6, double p7)
       {
          
       }

        void BuildFurnaceBlock(double p1, double p2, double p3, double p4, double p5, double p6, double p7, double p8)
       {
           
       }

       public  void BuildFoundation(double foundationHeight, double foundationWidth, double foundationLength, double ashpitWidth, double ashpitHeight, double ashpitLength)
       {
           var radius = _outsideDiameter / 2; // Получение адреса по диаметру
           _part = (ksPart)_doc3D.GetPart((short)Part_Type.pTop_Part);
           ksSketchDefinition definitionSketch = null;
           ksEntity sketch = null;
           if (_part != null) // Проверка на существование компонента сборки
           {
               _baseSketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch); // Создание нового эскиз
               if (_baseSketch != null)
               {
                   definitionSketch = (ksSketchDefinition)_baseSketch.GetDefinition(); // Получение интерфейса свойств эскиза

                   if (definitionSketch != null)
                   {
                       // Получение интерфейса базовой плоскости XOY
                       var planeXOY = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
                       definitionSketch.SetPlane(planeXOY); // Размешаем эскиз на плоскости XOY

                       _baseSketch.Create();

                       // Редактирование эскиза
                       var sketchEdit = (ksDocument2D)definitionSketch.BeginEdit(); // Интерфейс редактора эскиза
                       sketchEdit.ksCircle(0, 0, radius, 1); // Cоздание окружности
                       definitionSketch.EndEdit();

                   }
               }
           }
       }*/

       
    }
}
