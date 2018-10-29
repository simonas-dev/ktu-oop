using SpaceInvaders.Domain.Models.GameComponents.GameBoard;
using SpaceInvaders.Domain.Models.Memento;
using SpaceInvaders.Domain.Models.Score;
using SpaceInvaders.Domain.Models.States;

namespace SpaceInvaders.Domain.Models
{
    // Builder - Depending on strategy generate gameboard with different parameters (level of enemies) - done, unit tests
    // Observer - Board is the subject to which enemies subscribe - observer pattern done, (tests done)
    // Strategy - Implement different strategies - done, unit tests
    // Factory -  pattern to construct strategy - done, unit tests
    // Singleton - only one game is available at one time - done (tests done)   

    // Facade - IWindowFacade facade - done, console tests
    // Command - pattern check if available to switch with string commands in view/controller - done
    // Prototype - to create enemies and copy when needed - done (tests done)
    // Adapter - Program expects GUI program, but gets console application interface - done, console tests
    // Decorator - decorate spaceship shoot method - done (tests done)

    // +Template Method - used to draw different game themes - done
    // +Iterator - going through enemies / level list -  done
    // Composite - UI implementation with components as leafs - done
    // +Flyweight - states as flyweights - done - tests done
    // +State - to track game states between started, running and ended - done - tests done

    // Chain of responsibility - depending on score go up in hierarchy of handlers - Paulius
    // +Null Object - Score null - Done
    // +Memento - restart/resume game level - done. Add to game or gamestate, depending on situation 
    // Interpreter - write console grammar for features in game - done
    // +Mediator - used in repository. The mediator will delegate our query objects to the appropriate handler that
    //  will perform the query and return the results. - done more info:(https://codeopinion.com/query-objects-with-a-mediator/) - tests done
    // +Visitor - when enemies die, depending on game difficulty, they visit visitor and add score to the sum - done - tests done

    public class Game
    {
        public GameBoard Board { get; set; }

        public Score.Score Score { get; set; }

        private IGamesState _state;
     
        public int Level { get; set; }

        private static Game _instance;

        public static Game Instance => _instance ?? (_instance = new Game
        {
            _state = new GameCreatedState(),
            Score = new NullScore()
        }); // Singleton

        private Game() { }

        public override string ToString()
        {
            return Board.ToString().Insert(0, $"Current score: {Score.Number} \n");
        }

        // GameState in GameStartedState updates score
        public void SetState(IGamesState state)
        {
            _state = state;
        }

        public IGamesState GetState()
        {
            return _state;
        }

        //Mementos things

        public GameMemento CreateMemento()
        {
            return new GameMemento(Level, Score.Number, Score.Date);
        }

        public void SetMemento(GameMemento memento)
        {
            Level = memento.Level;
            Score.Number = memento.Score;
            Score.Date = memento.Date;
        }
    }
}
