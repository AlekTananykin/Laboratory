﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    sealed class InteractiveStorage : 
        IInitialization, IExecute, ILateExecute, ICleanup, IInteractionStorage
    {
        private List<IInitialization> _initializationControllers;
        private List<IExecute> _executeControllers;
        private List<ILateExecute> _lateExecuteControllers;
        private List<ICleanup> _cleanupControllers;

        public InteractiveStorage()
        {
            _initializationControllers = new List<IInitialization>();
            _executeControllers = new List<IExecute>();
            _lateExecuteControllers = new List<ILateExecute>();
            _cleanupControllers = new List<ICleanup>();
        }

        public void Add(IInteractionObject controller)
        {
            if (controller is IInitialization initController)
            {
                _initializationControllers.Add(initController);
            }
            if (controller is IExecute execController)
            {
                _executeControllers.Add(execController);
            }
            if (controller is ILateExecute lateExecController)
            {
                _lateExecuteControllers.Add(lateExecController);
            }
            if (controller is ICleanup cleanupController)
            {
                _cleanupControllers.Add(cleanupController);
            }
        }

        public void Remove(IInteractionObject controller)
        {
            if (controller is IInitialization initController)
            {
                _initializationControllers.Remove(initController);
            }
            if (controller is IExecute execController)
            {
                _executeControllers.Remove(execController);
            }
            if (controller is ILateExecute lateExecController)
            {
                _lateExecuteControllers.Remove(lateExecController);
            }
            if (controller is ICleanup cleanupController)
            {
                _cleanupControllers.Remove(cleanupController);
                cleanupController.Cleanup();
            }
        }

        public void Initialization()
        {
            for (int i = 0; i < _initializationControllers.Count; ++i)
            {
                _initializationControllers[i].Initialization();
            }
        }

        public void Execute(float deltaTime)
        {
            for (int i = 0; i < _executeControllers.Count; ++i)
            {
                _executeControllers[i].Execute(deltaTime);
            }
        }

        public void LateExecute(float deltaTime)
        {
            for (int i = 0; i < _lateExecuteControllers.Count; ++i)
            {
                _lateExecuteControllers[i].LateExecute(deltaTime);
            }
        }

        public void Cleanup()
        {
            for (int i = 0; i < _cleanupControllers.Count; ++i)
            {
                _cleanupControllers[i].Cleanup();
            }
        }
    }
}
