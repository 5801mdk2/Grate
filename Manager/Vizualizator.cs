using System;
using DataControllManager;
using Model;
using Kompas6API5;

namespace Manager
{
    public class Vizualizator
    {
        /// <summary>
        /// Ссылка на объект KOMПАС-3D
        /// </summary>
        private KompasObject _kompas;

        /// <summary>
        /// Ссылка на экземпляр класса Grate
        /// </summary>
        private Grate _grate;

        /// <summary>
        /// Ссылка на интерфейс ksDocument3D
        /// </summary>
        private ksDocument3D _document3D;

        /// <summary>
        /// Инициализация параметров
        /// </summary>
        public void InitVizualizator(GrateDiscription grateDiscription, bool pipe)
        {
            OpenKompas();
            CreateDocument();

            _grate = new Grate(_kompas, _document3D, grateDiscription, pipe);
            _grate.CreateGrate();
        }

        /// <summary>
        /// Создание документа
        /// </summary>
        public void CreateDocument()
        {
            try
            {
                if (_kompas != null)
                {
                    CloseDocument();
                    if (_document3D == null)
                    {
                        // Создаем сборку
                        _document3D = (ksDocument3D) _kompas.Document3D();
                        _document3D.Create(false, false);
                        _document3D = (ksDocument3D) _kompas.ActiveDocument3D();
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                throw new NullReferenceException(@"Сначала откройте КОМПАС3D");
            }
        }

        /// <summary>
        /// Закрытие открытого документа
        /// </summary>
        public void CloseDocument()
        {
            if (_document3D != null)
            {
                _document3D.close();
                _document3D = null;
            }
        }

        /// <summary>
        /// Процедура открытия КОМПАС-3D.
        /// </summary>
        public void OpenKompas()
        {
            if (_kompas == null)
            {
                Type type = Type.GetTypeFromProgID("KOMPAS.Application.5");

                _kompas = (KompasObject)Activator.CreateInstance(type);
            }
            if (_kompas != null)
            {
                try
                {
                    _kompas.Visible = true;
                    _kompas.ActivateControllerAPI();
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
        }
    }
}
