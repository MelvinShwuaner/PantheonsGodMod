/* 
AUTHOR: MASON SCARBRO
VERSION: 1.0.0
*/
using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NCMS;
using NCMS.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ReflectionUtility;

namespace GodsAndPantheons
{
    class NewEffects : MonoBehaviour
    {
        public static void init()
        {
            loadEffects();
        }

        private static void loadEffects()
        {
            /*var effect1 = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_multiFlash_dej",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsBack",
                sprite_path = "effects/fx_multiFlash_dej",
                show_on_mini_map = true,
                use_basic_prefab = true,
                limit = 100,
                draw_light_area = true,
                draw_light_size = 2f,
                draw_light_area_offset_y = 0f
            });*/
            //World.world.stackEffects.CallMethod("add", effect1);

            var effect2 = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_smokeFlash_dej",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsBack",
                sprite_path = "effects/fx_smokeFlash_dej",
                show_on_mini_map = true,
                limit = 100,
                draw_light_area = true,
                draw_light_size = 2f,
                draw_light_area_offset_y = 0f,
                time_between_frames = 0.08f
            });
            World.world.stackEffects.CallMethod("add", effect2);

            var effect3 = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_cometAzureDown_dej",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsBack",
                sprite_path = "effects/fx_cometAzureDown_dej",
                show_on_mini_map = true,
                limit = 100,
                draw_light_area = true,
                draw_light_size = 2f,
                draw_light_area_offset_y = 0f,
                sound_launch = "event:/SFX/EXPLOSIONS/ExplosionAntimatterBomb",
                time_between_frames = 0.08f,
            });
            World.world.stackEffects.CallMethod("add", effect3);

            var effect4 = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_cometShower_dej",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsBack",
                sprite_path = "effects/fx_cometShower_dej",
                show_on_mini_map = true,
                limit = 100,
                draw_light_area = true,
                draw_light_size = 2f,
                draw_light_area_offset_y = 0f,
                time_between_frames = 0.09f
            });
            World.world.stackEffects.CallMethod("add", effect4);


            var effect5 = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_teleportStart_dej",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsBack",
                sprite_path = "effects/fx_teleportStart_dej",
                show_on_mini_map = true,
                limit = 100,
                draw_light_area = true,
                draw_light_size = 2f,
                draw_light_area_offset_y = 0f,
                time_between_frames = 0.06f
            });
            World.world.stackEffects.CallMethod("add", effect5);

            var effect6 = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_teleportEnd_dej",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsBack",
                sprite_path = "effects/fx_teleportEnd_dej",
                show_on_mini_map = true,
                limit = 100,
                draw_light_area = true,
                draw_light_size = 2f,
                draw_light_area_offset_y = 0f,
                time_between_frames = 0.08f
            });
            World.world.stackEffects.CallMethod("add", effect6);

            var effect7 = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_handgrab_dej",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsBack",
                sprite_path = "effects/fx_handgrab_dej",
                show_on_mini_map = true,
                limit = 100,
                draw_light_area = true,
                draw_light_size = 2f,
                draw_light_area_offset_y = 0f,
                time_between_frames = 0.1f
            });
            World.world.stackEffects.CallMethod("add", effect7);
            var Effect8 = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_Heart",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsBack",
                sprite_path = "effects/projectiles/Heart",
                sound_launch = "event:/SFX/WEAPONS/WeaponFireballStart",
                show_on_mini_map = true,
                limit = 100,
                draw_light_area = true,
                draw_light_size = 2f,
                draw_light_area_offset_y = 0f,
                time_between_frames = 0.1f
            });
            World.world.stackEffects.CallMethod("add", Effect8);
            var Effect9 = AssetManager.effects_library.clone("fx_Heart_Corrupted", "fx_Heart");
            Effect9.sprite_path = "effects/projectiles/CorruptedHeart";
            World.world.stackEffects.CallMethod("add", Effect9);
            //World.world.stackEffects.checkInit();
        }
    }
}