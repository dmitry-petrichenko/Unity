using System.Collections.Generic;
using Entitas;

public class DisplayHexagonTypeSystem : ReactiveSystem<GameEntity>
{

  private Contexts _contexts;
  
  public DisplayHexagonTypeSystem(Contexts contexts) : base(contexts.game)
  {
      _contexts = contexts;
  }

  protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
  {
        return context.CreateCollector(GameMatcher.HexagonType);
  }

  protected override bool Filter(GameEntity entity)
  {
   return entity.hasView && entity.hasHexagonType;
  }

  protected override void Execute(List<GameEntity> entities)
  {
   foreach (var entity in entities)
   {
     entity.view.value.GetComponent<HexagonViewBehaviour>().SetType(entity.hexagonType.value);
   }
  }
 }