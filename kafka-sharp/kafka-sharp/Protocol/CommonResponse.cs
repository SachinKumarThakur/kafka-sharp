﻿using System;
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0

using System.IO;

namespace Kafka.Protocol
{
    struct CommonResponse<TPartitionData> where TPartitionData: IMemoryStreamSerializable, new()
    {
        public TopicData<TPartitionData>[] TopicsResponse;

        public static CommonResponse<TPartitionData> Deserialize(byte[] body)
        {
            using (var stream = new MemoryStream(body))
            {
                return new CommonResponse<TPartitionData>
                {
                    TopicsResponse =
                        Basics.DeserializeArray<TopicData<TPartitionData>>(stream)
                };
            }
        }
    }
}