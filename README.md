# tamagotchi
Логика действия лечения:

восстанавливает 5 единиц здоровья, но понижает уровень усталости на 2;
   
при избыточном лечении повышает усталость ещё на один пункт (т.о. усталость повысится на 3 пункта за одно лечение), под избыточным лечением понимается ситуация, когда сумма уровня здоровья до лечения и восстановленных 5 единиц за лечение превышает максимальный уровень здоровья (т.е. становится больше 10);
   
если при этом уровень усталости питомца достигает критического уровня (в сумме уровня до лечения и единиц усталости полученных за лечение даёт больше 10 единиц), то питомец сразу же теряет 1 единицу здоровья.

Файлы для логирования и сохранения последнего состояния сохраняются в директории проекта
