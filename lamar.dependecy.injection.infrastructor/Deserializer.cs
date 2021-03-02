using System;
using System.Collections.Generic;
using System.Text.Json;
using lamar.dependecy.injection.domain;

namespace lamar.dependecy.injection.infrastructor
{
    public static class Deserializer
    {
        public static T jsonDeserializer<T>(string json)
        {
            var deserializedObject =  JsonSerializer.Deserialize<T>(json);

            return deserializedObject;
        }
    }
}
