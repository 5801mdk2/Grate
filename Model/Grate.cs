using DataControllManager;
using Kompas6API5;
using Kompas6Constants3D;

namespace Model
{
    public class Grate
    {
        /// <summary>
        /// Ссылка на объект KOMПАС-3D
        /// </summary>
        private KompasObject _kompas;

        /// <summary>
        /// Ссылка на документ
        /// </summary>
        private ksDocument3D _document3D;

        /// <summary>
        /// Ссылка на класс GrateDescription
        /// </summary>
        private GrateDiscription _grateDiscription;

        /// <summary>
        /// Ссылка на компонент сборки
        /// </summary>
        private ksPart _part;

        /// <summary>
        /// Ссылка на базовую плоскость
        /// </summary>
        private ksEntity _baseSketch;


        /// <summary>
        /// Поле, описывающее возможность построения трубы 
        /// </summary>
        private bool _isPipeExist;

        /// <summary>
        /// Конструктор, инициализирующий поля класса по входным параметрам
        /// </summary>
        /// <param name="kompas">Ссылка на интерфейс KompasObject</param>
        /// <param name="document3D">Ссылка на сборку</param>
        /// <param name="grateDiscription">Экземпляр класса</param>
        /// <param name="isPipe">Переменная булевского типа</param>
        public Grate(KompasObject kompas, ksDocument3D document3D, GrateDiscription grateDiscription, bool isPipe)
        {
            // TODO: Complete member initialization
            _kompas = kompas;
            _document3D = document3D;
            _grateDiscription = grateDiscription;
            _isPipeExist = isPipe;

        }

        /// <summary>
        ///Построение модели 
        /// </summary>
        public void CreateGrate()
        {
           
            BuildFoundation(); //Создание фундаента
            PressBase(_grateDiscription.FoundationHeight);//Выдавливание основания
            BuildAshipt(); //Создание поддувала
            BuildFoundationPlate(); //Создание надфундаментной плиты
            BuildFurnaceBlock(); //Создание печного блока
            BuildBurner(); //Создание топки
            BuildChimney(); //Вырезание дымоходного отверстия
            BuildPerf();//Вырезание перфараций

            if (_isPipeExist)
            {
                BuildPipe(); //Построение трубы
                CreateMantel(); //Построение оконтовки конца трубы
                CreateCutPipe(); //Вырезание отверстия трубы
            }

        }

        /// <summary>
        /// Создание фундамента
        /// </summary>
        private void BuildFoundation()
        {
            _part = (ksPart)_document3D.GetPart((short)Part_Type.pTop_Part);

            if (_part != null) // Проверка на существование компонента сборки
            {
                _baseSketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch); // Создание нового эскиз
                if (_baseSketch != null)
                {
                    var definitionSketch = (ksSketchDefinition)_baseSketch.GetDefinition();

                    if (definitionSketch != null)
                    {
                        // Получение интерфейса базовой плоскости XOY
                        var planeXOY = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
                        definitionSketch.SetPlane(planeXOY); // Размешаем эскиз на плоскости XOY

                        _baseSketch.Create();
                 
                        ksDocument2D _sketchFoundation = definitionSketch.BeginEdit();
                        DrawFoundation(_sketchFoundation);
                        
                        definitionSketch.EndEdit();
                    }
                }
            }
        }

        /// <summary>
        /// Отрисовка эскиза фундамента
        /// </summary>
        private void DrawFoundation(ksDocument2D _sketchFoundation)
        {
            if (_sketchFoundation != null)
            {
                _sketchFoundation.ksLineSeg(-_grateDiscription.FoundationLength/2, _grateDiscription.FoundationWidth/2,
                    _grateDiscription.FoundationLength/2,
                    _grateDiscription.FoundationWidth/2, 1);


                _sketchFoundation.ksLineSeg(_grateDiscription.FoundationLength/2, _grateDiscription.FoundationWidth/2,
                    _grateDiscription.FoundationLength/2,
                    -_grateDiscription.FoundationWidth/2, 1);

                _sketchFoundation.ksLineSeg(_grateDiscription.FoundationLength/2, -_grateDiscription.FoundationWidth/2,
                    -_grateDiscription.FoundationLength/2,
                    -_grateDiscription.FoundationWidth/2, 1);

                _sketchFoundation.ksLineSeg(-_grateDiscription.FoundationLength/2, -_grateDiscription.FoundationWidth/2,
                    -_grateDiscription.FoundationLength/2,
                    _grateDiscription.FoundationWidth/2, 1);
            }
        }

        /// <summary>
        /// Создание поддувала
        /// </summary>
        private void BuildAshipt()
        {
            _part = (ksPart)_document3D.GetPart((short)Part_Type.pTop_Part);

            if (_part != null) // Проверка на существование компонента сборки
            {
                _baseSketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch); // Создание нового эскиз
                if (_baseSketch != null)
                {
                    var definitionSketch = (ksSketchDefinition)_baseSketch.GetDefinition();

                    if (definitionSketch != null)
                    {
                        // Получение интерфейса базовой плоскости YOZ
                        var basePlane = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeYOZ); //берем плоскость YOZ
                        ksEntity _ofsetPlane = _part.NewEntity((short)Obj3dType.o3d_planeOffset);

                        ksPlaneOffsetDefinition _ofsetPlaneDef = _ofsetPlane.GetDefinition();
                        _ofsetPlaneDef.direction = true; //прямое направление смещения плоскости
                        _ofsetPlaneDef.offset = _grateDiscription.FoundationLength / 2; //расстояние смещения плоскости
                        _ofsetPlaneDef.SetPlane(basePlane);
                        _ofsetPlane.Create();

                        ksEntity _sketch = _part.NewEntity((short)Obj3dType.o3d_sketch);
                        ksSketchDefinition _sketchDef = _sketch.GetDefinition();
                        _sketchDef.SetPlane(_ofsetPlane);

                        _sketch.Create();

                        //получение эскиз поддувала
                        ksDocument2D _ashiptSketch = _sketchDef.BeginEdit();
                        DrawAshipt(_ashiptSketch);
                        //выход из режима редактирования эскиза
                        _sketchDef.EndEdit();

                        //вырезание поддувала
                        CutObject(_sketch, _grateDiscription.AshpitLength, true, true);
                    }
                }
            }
        }

        /// <summary>
        /// Отрисовка эскиза поддувала
        /// </summary>
        private void DrawAshipt(ksDocument2D _ashiptSketch)
        {
            if (_ashiptSketch != null)
            {
                _ashiptSketch.ksLineSeg((_grateDiscription.AshpitHeight - _grateDiscription.FoundationHeight), _grateDiscription.AshpitWidth / 2,
                    (_grateDiscription.AshpitHeight / 2 - _grateDiscription.FoundationHeight / 2), _grateDiscription.AshpitWidth / 2, 1);
                _ashiptSketch.ksLineSeg((_grateDiscription.AshpitHeight / 2 - _grateDiscription.FoundationHeight / 2), _grateDiscription.AshpitWidth / 2,
                    (_grateDiscription.AshpitHeight / 2 - _grateDiscription.FoundationHeight / 2), -_grateDiscription.AshpitWidth / 2, 1);
                _ashiptSketch.ksLineSeg((_grateDiscription.AshpitHeight / 2 - _grateDiscription.FoundationHeight / 2), -_grateDiscription.AshpitWidth / 2,
                    (_grateDiscription.AshpitHeight - _grateDiscription.FoundationHeight), -_grateDiscription.AshpitWidth / 2, 1);
                _ashiptSketch.ksLineSeg((_grateDiscription.AshpitHeight - _grateDiscription.FoundationHeight), -_grateDiscription.AshpitWidth / 2,
                    (_grateDiscription.AshpitHeight - _grateDiscription.FoundationHeight), _grateDiscription.AshpitWidth / 2, 1);
            }
        }

        /// <summary>
        /// Создание надфундаментной плиты
        /// </summary>
        private void BuildFoundationPlate()
        {
             _part = (ksPart)_document3D.GetPart((short)Part_Type.pTop_Part);

            if (_part != null) // Проверка на существование компонента сборки
              {
                  _baseSketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch); // Создание нового эскиз
                  if (_baseSketch != null)
                  {
                      var definitionSketch = (ksSketchDefinition)_baseSketch.GetDefinition();

                      if (definitionSketch != null)
                      {
                          var basePlaneFoundationPlate =
                              (ksEntity) _part.GetDefaultEntity((short) Obj3dType.o3d_planeXOY); //берем плоскость XOY

                          ksEntity _ofsetPlane = _part.NewEntity((short) Obj3dType.o3d_planeOffset);
                              // Получение интерфейса базовой плоскости XOY
                          ksPlaneOffsetDefinition _ofsetPlaneDef = _ofsetPlane.GetDefinition();
                          _ofsetPlaneDef.direction = true; //прямое направление смещения плоскости
                          _ofsetPlaneDef.offset = _grateDiscription.FoundationHeight; //расстояние смещения плоскости
                          _ofsetPlaneDef.SetPlane(basePlaneFoundationPlate); //устанавливаем базовую плоскость
                          _ofsetPlane.Create(); //создаем смещенную плоскость

                          ksEntity _sketch = _part.NewEntity((short) Obj3dType.o3d_sketch);
                              //получаем интерфейс объекта "Эскиз"
                          ksSketchDefinition _sketchDefinition = _sketch.GetDefinition();
                              //получаем интерфийс параметров эскиза
                          _sketchDefinition.SetPlane(_ofsetPlane); //устанавливаем смещенную плоскость базовой
                          _sketch.Create(); //создаем эсктз

                          //получение эскиза плиты
                          ksDocument2D _foundationPlateSketch = _sketchDefinition.BeginEdit();
                          DrawFoundationPlate(_foundationPlateSketch);

                          //выходим из режима редактирования эскиза
                          _sketchDefinition.EndEdit();

                          // выдавливание плиты
                          BossExtrusion(_sketch, _grateDiscription.FoundationPlateHeight);
                      }
                  }
              } 
        }

        /// <summary>
        /// Отрисовка эскиза надфундаментной плиты
        /// </summary>
        private void DrawFoundationPlate(ksDocument2D _foundationPlateScetch)
        {
            if (_foundationPlateScetch != null)
            {
                _foundationPlateScetch.ksLineSeg(-_grateDiscription.FoundationPlateLength / 2, _grateDiscription.FoundationPlateWidth / 2,
                    _grateDiscription.FoundationLength / 2, _grateDiscription.FoundationPlateWidth / 2, 1);
                _foundationPlateScetch.ksLineSeg(_grateDiscription.FoundationLength / 2, _grateDiscription.FoundationPlateWidth / 2,
                    _grateDiscription.FoundationLength / 2, -_grateDiscription.FoundationPlateWidth / 2, 1);
                _foundationPlateScetch.ksLineSeg(_grateDiscription.FoundationLength / 2, -_grateDiscription.FoundationPlateWidth / 2,
                    -_grateDiscription.FoundationPlateLength / 2, -_grateDiscription.FoundationPlateWidth / 2, 1);
                _foundationPlateScetch.ksLineSeg(-_grateDiscription.FoundationPlateLength / 2, -_grateDiscription.FoundationPlateWidth / 2,
                    -_grateDiscription.FoundationPlateLength / 2, _grateDiscription.FoundationPlateWidth / 2, 1);
            }
        }

        /// <summary>
        /// Создание печного блока
        /// </summary>
        private void BuildFurnaceBlock()
        {
            _part = (ksPart)_document3D.GetPart((short)Part_Type.pTop_Part);

            if (_part != null) // Проверка на существование компонента сборки
            {
                _baseSketch = (ksEntity) _part.NewEntity((short) Obj3dType.o3d_sketch); // Создание нового эскиз

                if (_baseSketch != null)
                {
                    // Получение интерфейса свойств эскиза
                    var definitionSketch = (ksSketchDefinition) _baseSketch.GetDefinition();

                    if (definitionSketch != null)
                    {
                        var basePlaneFurnaceBlock = (ksEntity) _part.GetDefaultEntity((short) Obj3dType.o3d_planeXOY); //берем плоскость XOY

                        ksEntity _ofsetPlane = _part.NewEntity((short) Obj3dType.o3d_planeOffset);
                        // Получение интерфейса базовой плоскости XOY
                        ksPlaneOffsetDefinition _ofsetPlaneDef = _ofsetPlane.GetDefinition();
                        _ofsetPlaneDef.direction = true; //прямое направление смещения плоскости
                        _ofsetPlaneDef.offset = _grateDiscription.FoundationHeight + _grateDiscription.FoundationPlateHeight;
                        //расстояние смещения плоскости
                        _ofsetPlaneDef.SetPlane(basePlaneFurnaceBlock); //устанавливаем базовую плоскость
                        _ofsetPlane.Create(); //создаем смещенную плоскость

                        ksEntity _sketch = _part.NewEntity((short)Obj3dType.o3d_sketch); //получаем интерфейс объекта "Эскиз"
                        ksSketchDefinition _sketchDefinition = _sketch.GetDefinition();//получаем интерфийс параметров эскиза
                        _sketchDefinition.SetPlane(_ofsetPlane);//устанавливаем смещенную плоскость базовой
                        _sketch.Create();//создаем эсктз

                        ksDocument2D _furnaceBlockSketch = _sketchDefinition.BeginEdit();//входим в режим редактирования эскиза
                        DrawFurnaceBlock(_furnaceBlockSketch);

                        //выходим из режима редактирования эскиза
                        _sketchDefinition.EndEdit();

                        //выдавливание печного блока
                        BossExtrusion(_sketch, _grateDiscription.FurnaceBlockHeight);
                    }
                }
            }
        }

        /// <summary>
        /// Отрисовка эскиза печного блока
        /// </summary>
        private void DrawFurnaceBlock(ksDocument2D _furnaceBlockSketch)
        {
            if (_furnaceBlockSketch != null)
            {
                //рисуем прямоугольник линиями
                _furnaceBlockSketch.ksLineSeg(-_grateDiscription.FurnaceBlockLength / 2, _grateDiscription.FurnaceBlockWidth / 2,
                    _grateDiscription.FoundationLength / 2, _grateDiscription.FurnaceBlockWidth / 2, 1);
                _furnaceBlockSketch.ksLineSeg(_grateDiscription.FoundationLength / 2, _grateDiscription.FurnaceBlockWidth / 2,
                    _grateDiscription.FoundationLength / 2, -_grateDiscription.FurnaceBlockWidth / 2, 1);
                _furnaceBlockSketch.ksLineSeg(_grateDiscription.FoundationLength / 2, -_grateDiscription.FurnaceBlockWidth / 2,
                    -_grateDiscription.FurnaceBlockLength / 2, -_grateDiscription.FurnaceBlockWidth / 2, 1);
                _furnaceBlockSketch.ksLineSeg(-_grateDiscription.FurnaceBlockLength / 2, -_grateDiscription.FurnaceBlockWidth / 2,
                    -_grateDiscription.FurnaceBlockLength / 2, _grateDiscription.FurnaceBlockWidth / 2, 1);
            }
        }

        /// <summary>
        /// Создание топки
        /// </summary>
        private void BuildBurner()
        {
            _part = (ksPart)_document3D.GetPart((short)Part_Type.pTop_Part);

            if (_part != null) // Проверка на существование компонента сборки
            {
                _baseSketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch); // Создание нового эскиз
                if (_baseSketch != null)
                {
                    var definitionSketch = (ksSketchDefinition)_baseSketch.GetDefinition();

                    if (definitionSketch != null)
                    {

                        // Получение интерфейса базовой плоскости YOZ
                        var basePlaneBurner = (ksEntity) _part.GetDefaultEntity((short) Obj3dType.o3d_planeXOY);
                            //берем плоскость XOY

                        ksEntity _ofsetPlane = _part.NewEntity((short) Obj3dType.o3d_planeOffset);
                        // Получение интерфейса базовой плоскости XOY
                        ksPlaneOffsetDefinition _ofsetPlaneDef = _ofsetPlane.GetDefinition();
                        _ofsetPlaneDef.direction = true; //прямое направление смещения плоскости
                        _ofsetPlaneDef.offset = _grateDiscription.FoundationHeight +
                                                _grateDiscription.FoundationPlateHeight/2;
                        //расстояние смещения плоскости
                        _ofsetPlaneDef.SetPlane(basePlaneBurner); //устанавливаем базовую плоскость
                        _ofsetPlane.Create(); //создаем смещенную плоскость

                        ksEntity _sketch = _part.NewEntity((short) Obj3dType.o3d_sketch);
                        ksSketchDefinition _sketchDef = _sketch.GetDefinition();
                        _sketchDef.SetPlane(_ofsetPlane);

                        _sketch.Create();

                        //получение эскиза топки
                        ksDocument2D _sketchBurner = _sketchDef.BeginEdit();
                        DrawBurner(_sketchBurner);
                        
                        _sketchDef.EndEdit();

                        //вырезание топки
                        CutObject(_sketch, _grateDiscription.BurnerHeight, false, true);
                    }
                }
            }
        }

        /// <summary>
        /// Отрисовка эскиза топки
        /// </summary>
        private void DrawBurner(ksDocument2D _sketchBurner)
        {
            if (_sketchBurner != null)
            {
                _sketchBurner.ksLineSeg(-_grateDiscription.FurnaceBlockLength/2, _grateDiscription.BurnerWidth/2,
                    _grateDiscription.FoundationLength/2 - 2.5, _grateDiscription.BurnerWidth/2, 1);
                _sketchBurner.ksLineSeg(_grateDiscription.FoundationLength/2 - 2.5, _grateDiscription.BurnerWidth/2,
                    _grateDiscription.FoundationLength/2 - 2.5, -_grateDiscription.BurnerWidth/2, 1);
                _sketchBurner.ksLineSeg(_grateDiscription.FoundationLength/2 - 2.5,
                    -_grateDiscription.BurnerWidth/2,
                    -_grateDiscription.FurnaceBlockLength/2, -_grateDiscription.BurnerWidth/2, 1);
                _sketchBurner.ksLineSeg(-_grateDiscription.FurnaceBlockLength/2, -_grateDiscription.BurnerWidth/2,
                    -_grateDiscription.FurnaceBlockLength/2, _grateDiscription.BurnerWidth/2, 1);
            }
        }

        /// <summary>
        /// Создание дымохода
        /// </summary>
        private void BuildChimney()
        {
            _part = (ksPart)_document3D.GetPart((short)Part_Type.pTop_Part);

            if (_part != null) // Проверка на существование компонента сборки
            {
                _baseSketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch); // Создание нового эскиз
                if (_baseSketch != null)
                {
                    var definitionSketch = (ksSketchDefinition)_baseSketch.GetDefinition();

                    if (definitionSketch != null)
                    {

                        // Получение интерфейса базовой плоскости XOY
                        var basePlaneChimney = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY); //берем плоскость XOY

                        ksEntity _ofsetPlane = _part.NewEntity((short)Obj3dType.o3d_planeOffset);
                        // Получение интерфейса базовой плоскости XOY
                        ksPlaneOffsetDefinition _ofsetPlaneDef = _ofsetPlane.GetDefinition();
                        _ofsetPlaneDef.direction = true; //прямое направление смещения плоскости
                        _ofsetPlaneDef.offset = _grateDiscription.FoundationHeight + _grateDiscription.FoundationPlateHeight + _grateDiscription.FurnaceBlockHeight;
                        //расстояние смещения плоскости
                        _ofsetPlaneDef.SetPlane(basePlaneChimney); //устанавливаем базовую плоскость
                        _ofsetPlane.Create(); //создаем смещенную плоскость

                        ksEntity _sketch = _part.NewEntity((short)Obj3dType.o3d_sketch);
                        ksSketchDefinition _sketchDef = _sketch.GetDefinition();
                        _sketchDef.SetPlane(_ofsetPlane);

                        _sketch.Create();

                        //получаем эскиз топки
                        ksDocument2D sketchEdit = (ksDocument2D)_sketchDef.BeginEdit();
                        ksRectangleParam _param = (ksRectangleParam)_kompas.GetParamStruct((short)Kompas6Constants.StructType2DEnum.ko_RectangleParam);
                        DrawChimney(_param);
                        
                        //Строим сам прямоугольник c обозначением центра
                        sketchEdit.ksRectangle(_param, 1);

                        _sketchDef.EndEdit();

                        //вырезание дымохода
                        CutObject(_sketch, _grateDiscription.FurnaceBlockHeight - _grateDiscription.BurnerHeight + _grateDiscription.FoundationPlateHeight / 2, false, false);
                    }
                }
            }
        }

        /// <summary>
        /// Отрисовка эскиза дымохода
        /// </summary>
        private void DrawChimney(ksRectangleParam _param)
        {
            _param.height = _grateDiscription.ChimneyHeight;
            _param.style = 1;
            _param.width = _grateDiscription.ChimneyWidth;
            _param.x = -5;
            _param.y = -9;
        }

        /// <summary>
        /// Создание перфараций поддувала
        /// </summary>
        private void BuildPerf()
        {
            _part = (ksPart)_document3D.GetPart((short)Part_Type.pTop_Part);

            if (_part != null) // Проверка на существование компонента сборки
            {
                _baseSketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch); // Создание нового эскиз
                if (_baseSketch != null)
                {
                    var definitionSketch = (ksSketchDefinition)_baseSketch.GetDefinition();

                    if (definitionSketch != null)
                    {

                        // Получение интерфейса базовой плоскости XOY
                        var basePlaneChimney = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY); //берем плоскость XOY

                        ksEntity _ofsetPlane = _part.NewEntity((short)Obj3dType.o3d_planeOffset);
                        // Получение интерфейса базовой плоскости XOY
                        ksPlaneOffsetDefinition _ofsetPlaneDef = _ofsetPlane.GetDefinition();
                        _ofsetPlaneDef.direction = true; //прямое направление смещения плоскости
                        _ofsetPlaneDef.offset = _grateDiscription.FoundationHeight + _grateDiscription.FoundationPlateHeight/2;
                        //расстояние смещения плоскости
                        _ofsetPlaneDef.SetPlane(basePlaneChimney); //устанавливаем базовую плоскость
                        _ofsetPlane.Create(); //создаем смещенную плоскость

                        ksEntity _sketch = _part.NewEntity((short)Obj3dType.o3d_sketch);
                        ksSketchDefinition _sketchDef = _sketch.GetDefinition();
                        _sketchDef.SetPlane(_ofsetPlane);

                        _sketch.Create();

                        ksDocument2D _sketchEdit = (ksDocument2D)_sketchDef.BeginEdit();
                        ksRectangleParam _param = (ksRectangleParam)_kompas.GetParamStruct((short)Kompas6Constants.StructType2DEnum.ko_RectangleParam);
                        ksRectangleParam _param2 = (ksRectangleParam)_kompas.GetParamStruct((short)Kompas6Constants.StructType2DEnum.ko_RectangleParam);
                        ksRectangleParam _param3 = (ksRectangleParam)_kompas.GetParamStruct((short)Kompas6Constants.StructType2DEnum.ko_RectangleParam);
                        DrawPerf(_param, _param2, _param3);
                        
                        _sketchEdit.ksRectangle(_param, 1);
                        _sketchEdit.ksRectangle(_param2, 1);
                        _sketchEdit.ksRectangle(_param3, 1);
 
                        _sketchDef.EndEdit();

                        //вырезание перфараций
                        CutObject(_sketch, _grateDiscription.FoundationPlateHeight + 5, true, true);
                    }
                }
            }
        }

        /// <summary>
        /// Отрисовка эскизов перфараций
        /// </summary>
        private void DrawPerf(ksRectangleParam _param, ksRectangleParam _param2, ksRectangleParam _param3)
        {
            _param.height = 1.3;
            _param.style = 1;
            _param.width = 21;
            _param.x = -15;
            _param.y = -5.5;

            _param2.height = 1.3;
            _param2.style = 1;
            _param2.width = 21;
            _param2.x = -15;
            _param2.y = -0.6;

            _param3.height = 1.3;
            _param3.style = 1;
            _param3.width = 21;
            _param3.x = -15;
            _param3.y = 3.7;
        }

        /// <summary>
        /// Создание трубы
        /// </summary>
        private void BuildPipe()
        {
            _part = (ksPart) _document3D.GetPart((short) Part_Type.pTop_Part);

            if (_part != null) // Проверка на существование компонента сборки
            {
                _baseSketch = (ksEntity) _part.NewEntity((short) Obj3dType.o3d_sketch); // Создание нового эскиз
                if (_baseSketch != null)
                {
                    var definitionSketch = (ksSketchDefinition) _baseSketch.GetDefinition();
                    // Получение интерфейса свойств эскиза

                    if (definitionSketch != null)
                    {

                        // Получение интерфейса базовой плоскости XOY
                        var basePlanePipe = (ksEntity) _part.GetDefaultEntity((short) Obj3dType.o3d_planeXOY);
                        //берем плоскость XOY

                        ksEntity _ofsetPlane = _part.NewEntity((short) Obj3dType.o3d_planeOffset);
                        // Получение интерфейса базовой плоскости XOY
                        ksPlaneOffsetDefinition _ofsetPlaneDef = _ofsetPlane.GetDefinition();
                        _ofsetPlaneDef.direction = true; //прямое направление смещения плоскости
                        _ofsetPlaneDef.offset = _grateDiscription.FoundationHeight +
                                                _grateDiscription.FoundationPlateHeight +
                                                _grateDiscription.FurnaceBlockHeight;
                        //расстояние смещения плоскости
                        _ofsetPlaneDef.SetPlane(basePlanePipe); //устанавливаем базовую плоскость
                        _ofsetPlane.Create(); //создаем смещенную плоскость

                        ksEntity _sketch = _part.NewEntity((short) Obj3dType.o3d_sketch);
                        ksSketchDefinition _sketchDef = _sketch.GetDefinition();
                        _sketchDef.SetPlane(_ofsetPlane);

                        _sketch.Create();

                        ksDocument2D sketchEdit = (ksDocument2D) _sketchDef.BeginEdit();
                        ksRectangleParam _param =
                            (ksRectangleParam)
                                _kompas.GetParamStruct((short) Kompas6Constants.StructType2DEnum.ko_RectangleParam);

                        DrawPipe(_param);

                        sketchEdit.ksRectangle(_param, 1);

                        _sketchDef.EndEdit();

                        //Выдавливание трубы
                        BossExtrusion(_sketch, _grateDiscription.PipeHeight - _grateDiscription.MantelHeight);
                    }
                }
            }
        }

        /// <summary>
        /// Отрисовка эскиза трубы
        /// </summary>
        private void DrawPipe(ksRectangleParam _param)
        {
            _param.height = _grateDiscription.ChimneyHeight + 3;
            _param.style = 1;
            _param.width = _grateDiscription.ChimneyWidth + 3;
            _param.x = -6.5;
            _param.y = -10.5;
        }

        /// <summary>
        /// Вырезание отверстия трубы
        /// </summary>
        private void CreateCutPipe()
        {
            _part = (ksPart) _document3D.GetPart((short) Part_Type.pTop_Part);

            if (_part != null) // Проверка на существование компонента сборки
            {
                _baseSketch = (ksEntity) _part.NewEntity((short) Obj3dType.o3d_sketch); // Создание нового эскиз
                if (_baseSketch != null)
                {
                    var definitionSketch = (ksSketchDefinition) _baseSketch.GetDefinition();
                    // Получение интерфейса свойств эскиза

                    if (definitionSketch != null)
                    {
                        // Получение интерфейса базовой плоскости XOY
                        var basePlanePipe = (ksEntity) _part.GetDefaultEntity((short) Obj3dType.o3d_planeXOY);
                        //берем плоскость XOY

                        ksEntity _ofsetPlane = _part.NewEntity((short) Obj3dType.o3d_planeOffset);
                        // Получение интерфейса базовой плоскости XOY
                        ksPlaneOffsetDefinition _ofsetPlaneDef = _ofsetPlane.GetDefinition();
                        _ofsetPlaneDef.direction = true; //прямое направление смещения плоскости
                        _ofsetPlaneDef.offset = _grateDiscription.FoundationHeight + _grateDiscription.FoundationPlateHeight + _grateDiscription.FurnaceBlockHeight;
                        //расстояние смещения плоскости
                        _ofsetPlaneDef.SetPlane(basePlanePipe); //устанавливаем базовую плоскость
                        _ofsetPlane.Create(); //создаем смещенную плоскость

                        ksEntity _sketch = _part.NewEntity((short) Obj3dType.o3d_sketch);
                        ksSketchDefinition _sketchDef = _sketch.GetDefinition();
                        _sketchDef.SetPlane(_ofsetPlane);

                        _sketch.Create();

                        ksDocument2D sketchEditCut = (ksDocument2D) _sketchDef.BeginEdit();
                        ksRectangleParam _paramCut = (ksRectangleParam)_kompas.GetParamStruct((short) Kompas6Constants.StructType2DEnum.ko_RectangleParam);
                        DrawCutPipe(_paramCut);
                        sketchEditCut.ksRectangle(_paramCut, 1);
                        //выходим из режима редактирования эскиза
                        _sketchDef.EndEdit();

                        //вырезание отверстия в трубе
                        CutObject(_sketch, _grateDiscription.PipeHeight + _grateDiscription.MantelHeight, false, true);
                    }
                }
            }
        }

        /// <summary>
        /// Отрисовка эскиза отверстия трубы
        /// </summary>
        private void DrawCutPipe(ksRectangleParam _paramCut)
        {
            _paramCut.height = _grateDiscription.ChimneyHeight;
            _paramCut.style = 1;
            _paramCut.width = _grateDiscription.ChimneyWidth;
            _paramCut.x = -5;
            _paramCut.y = -9;
        }

        /// <summary>
        /// Создание огранки
        /// </summary>
        private void CreateMantel()
        {
            _part = (ksPart)_document3D.GetPart((short)Part_Type.pTop_Part);

            if (_part != null) // Проверка на существование компонента сборки
            {
                _baseSketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch); // Создание нового эскиз
                if (_baseSketch != null)
                {
                    var definitionSketch = (ksSketchDefinition)_baseSketch.GetDefinition();
                    // Получение интерфейса свойств эскиза

                    if (definitionSketch != null)
                    {
                        // Получение интерфейса базовой плоскости XOY
                        var basePlaneMantel = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
                       
                        ksEntity _ofsetPlane = _part.NewEntity((short)Obj3dType.o3d_planeOffset);
                        ksPlaneOffsetDefinition _ofsetPlaneDef = _ofsetPlane.GetDefinition();
                        _ofsetPlaneDef.direction = true; //прямое направление смещения плоскости
                        _ofsetPlaneDef.offset = _grateDiscription.FoundationHeight + _grateDiscription.FoundationPlateHeight +
                                                _grateDiscription.FurnaceBlockHeight + (_grateDiscription.PipeHeight - _grateDiscription.MantelHeight);
                       _ofsetPlaneDef.SetPlane(basePlaneMantel); //устанавливаем базовую плоскость
                        _ofsetPlane.Create(); //создаем смещенную плоскость

                        ksEntity _sketch = _part.NewEntity((short)Obj3dType.o3d_sketch);
                        ksSketchDefinition _sketchDef = _sketch.GetDefinition();
                        _sketchDef.SetPlane(_ofsetPlane);

                        _sketch.Create();

                        ksDocument2D sketchEdit = (ksDocument2D)_sketchDef.BeginEdit();
                        ksRectangleParam _param = (ksRectangleParam)_kompas.GetParamStruct((short)Kompas6Constants.StructType2DEnum.ko_RectangleParam);
                        DrawMantel(_param);
                       
                        sketchEdit.ksRectangle(_param, 1);
                        //выходим из режима редактирования эскиза
                        _sketchDef.EndEdit();

                        //Выдавливание огранки
                        BossExtrusion(_sketch, _grateDiscription.MantelHeight);
                    }
                }
            }
        }

        /// <summary>
        /// Отрисовка эскиза огранки
        /// </summary>
        private void DrawMantel(ksRectangleParam _param)
        {
            _param.height = _grateDiscription.ChimneyHeight + 6;
            _param.style = 1;
            _param.width = _grateDiscription.ChimneyWidth + 6;
            _param.x = -8;
            _param.y = -12;
        }

        /// <summary>
        /// Вырезать объект
        /// </summary>
        /// <param name="_sketch">Ссылка на эскиз объекта</param>
        /// <param name="length">Глубина вырезания</param>
        /// <param name="direction">Переменная типа булеан</param>
        /// <param name="angel">Переменная типа булеан</param>
        private void CutObject(ksEntity _sketch, double length, bool direction, bool angel)
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
                    cutExtrusionDefinition.directionType = (short) Direction_Type.dtNormal;
                    //Устанавливаем параметры выдавливания
                    cutExtrusionDefinition.SetSideParam(true, (short) End_Type.etBlind, length);
                }
                else
                {
                    //Прямое направление
                    cutExtrusionDefinition.directionType = (short) Direction_Type.dtReverse;
                    //Устанавливаем параметры выдавливания
                    cutExtrusionDefinition.SetSideParam(false, (short) End_Type.etBlind, length);
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
        private void PressBase(double _depth)
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
        private void BossExtrusion(ksEntity _sketch, double length)
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
    }
}
