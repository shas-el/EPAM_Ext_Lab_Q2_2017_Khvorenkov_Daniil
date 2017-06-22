/*
 * Создайте  иерархию  классов  и  пропишите  ключевые  методы  для компьютерной игры (без реализации функционала). Суть игры: 
 * 1. Игрок может передвигаться по прямоугольному полю размером Width на Height.
 * 2. На поле располагаются бонусы (яблоко, вишня и т.д.), которые игрок может подобрать для поднятия каких-либо характеристик.
 * 3. За игроком охотятся монстры (волки, медведи и т.д.), которые могут передвигаться по карте по какому-либо алгоритму.
 * 4. На  поле  располагаются  препятствия  разных  типов  (камни, деревья и т.д.), которые игрок и монстры должны обходить. 
 * Цель игры – собрать все бонусы и не быть «съеденным» монстрами.
 */

namespace Task04
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            Field field = new Field(30, 30);
            List<IGameObject> gameObjects = new List<IGameObject>();
            Player player = new Player();
            player.X = 1;
            player.Y = 1;
            Monster monster = new Wolf();
            monster.X = 10;
            monster.Y = 10;
            Bonus bonus = new Cherry();
            bonus.X = 20;
            bonus.Y = 20;
            gameObjects.Add(player);
            gameObjects.Add(monster);
            gameObjects.Add(bonus);
            
            foreach (IGameObject go in gameObjects)
            {
                field.Tiles[go.X, go.Y].GameObject = go;
            }

        }
    }
}
